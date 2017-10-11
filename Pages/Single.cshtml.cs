using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeTube.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WeTube.Pages
{
    public class SingleModel : PageModel
    {
        private readonly WeTube.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SingleModel(WeTube.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public List<Comment> Comments {get;set;}

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Comment")]
            public string Comment { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Movie = await _context.Movie
                .Include(m => m.ApplicationUser)  
                .SingleOrDefaultAsync(m => m.Id == id);

            Comments = await _context.Comment
                .Include(c => c.ApplicationUser)
                .Where(c=>c.ApplicationUserId == Movie.ApplicationUserId)
                .ToListAsync();

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            _context.Comment.Add(new Comment()
            {
                Description = Input.Comment,
                MovieId = Movie.Id,
                ApplicationUser = user
            });

            await _context.SaveChangesAsync();

            Movie = await _context.Movie
                .Include(m => m.Comments)
                .Include(m => m.ApplicationUser).SingleOrDefaultAsync(m => m.Id == Movie.Id);

            return Page();
        }
    }
}