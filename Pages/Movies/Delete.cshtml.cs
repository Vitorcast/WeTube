using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeTube.Data;
using WeTube.Services;

namespace WeTube.Pages_Movies
{
    public class DeleteModel : PageModel
    {
        private readonly WeTube.Data.ApplicationDbContext _context;
        private readonly VideoUploader _videoUploader;

        public DeleteModel(WeTube.Data.ApplicationDbContext context,
            VideoUploader videoUploader)
        {
            _context = context;
            _videoUploader = videoUploader;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
                .Include(m => m.ApplicationUser).SingleOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.Include(m=> m.Comments).FirstOrDefaultAsync(m=> m.Id==id);

            if (Movie != null)
            {
                await _videoUploader.Delete(Movie.Id);
                foreach (var comment in Movie.Comments)
                {
                    _context.Comment.Remove(comment);
                }
                _context.Movie.Remove(Movie);
                await _context.SaveChangesAsync();                
            }

            return RedirectToPage("./Index");
        }
    }
}
