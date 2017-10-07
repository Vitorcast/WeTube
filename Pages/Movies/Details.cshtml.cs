using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeTube.Data;

namespace WeTube.Pages_Movies
{
    public class DetailsModel : PageModel
    {
        private readonly WeTube.Data.ApplicationDbContext _context;

        public DetailsModel(WeTube.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
