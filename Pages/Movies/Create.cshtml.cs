using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeTube.Data;
using Microsoft.AspNetCore.Http;
using WeTube.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WeTube.Pages_Movies
{
    public class CreateModel : PageModel
    {
        private readonly WeTube.Data.ApplicationDbContext _context;
        private readonly VideoUploader _videoUploader;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(WeTube.Data.ApplicationDbContext context, 
            VideoUploader videoUploader,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _videoUploader = videoUploader;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["ApplicationUserId"] = _userManager.GetUserId(User);

        //ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync(List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Movie.ApplicationUserId = _userManager.GetUserId(User);

            if (files != null)
            {
                var fileUrl = await _videoUploader.Upload(files.FirstOrDefault(), Movie.Id);
                Movie.StorageUrl = fileUrl;
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
           

           
        }
    }
}