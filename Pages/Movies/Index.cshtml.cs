using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeTube.Data;
using Microsoft.AspNetCore.Identity;

namespace WeTube.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly WeTube.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(WeTube.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);

            Movie = await _context.Movie
                .Include(m => m.ApplicationUser)
                .Where(m => m.ApplicationUserId == ApplicationUser.Id)
                .ToListAsync();
        }

        public async Task OnPostAync()
        {

            ApplicationUser = await _userManager.GetUserAsync(User);

            Movie = await _context.Movie
                .Include(m => m.ApplicationUser)
                .Where(m => m.ApplicationUserId == ApplicationUser.Id)
                .ToListAsync();
        }
    }
}
