using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PI4.Data;
using PI4.Models;

namespace PI4.Pages
{
    public class DetailsModel : PageModel
    {
        public Video? Video { get; set; }

        public IEnumerable<Onderwerp> onderwerpen { get; set; } = null!;



        private VideoSubjectDbContext db;
        public DetailsModel(VideoSubjectDbContext injectedContext)
        {
            db = injectedContext;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            Video = await db.Videos.Include(v => v.Onderwerpen).SingleOrDefaultAsync(o => o.VideoId == id);

            if (Video == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
