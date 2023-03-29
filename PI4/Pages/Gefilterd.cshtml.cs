using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PI4.Models;
using PI4.Data;
using Microsoft.EntityFrameworkCore;

namespace PI4.Pages
{
    public class GefilterdModel : PageModel
    {
        public IEnumerable<Onderwerp> onderwerpen { get; set; } = null!;
        public Onderwerp? Onderwerp { get; set; }

        private VideoSubjectDbContext db;

        public GefilterdModel(VideoSubjectDbContext injectedContext)
        {
            db = injectedContext;
        }



        public async Task<IActionResult> OnGetAsync(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            



            Onderwerp = await db.Onderwerpen.Include(o => o.Videos).SingleOrDefaultAsync(v => v.OnderwerpId == id);

            
            if (Onderwerp == null)
            {
                return NotFound();
            }
            return Page();
        } 

    }
}