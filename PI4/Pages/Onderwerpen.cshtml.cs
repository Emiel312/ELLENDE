using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PI4.Data;
using Microsoft.EntityFrameworkCore;
using PI4.Models;

namespace PI4.Pages
{
    public class OnderwerpenModel : PageModel
    {
        public IEnumerable<Onderwerp> onderwerpen { get; set; } = null!;
        public string OmschrijvingSort { get; set; }

        private VideoSubjectDbContext db;
        public OnderwerpenModel(VideoSubjectDbContext injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet(string sortOrder)
        {
            onderwerpen = db.Onderwerpen.OrderBy(s => s.Omschrijving).ToList();
            OmschrijvingSort = sortOrder == "omschrijving" ? "omschrijving_desc" : "omschrijving";

            switch (sortOrder)
            {
                case "omschrijving_desc":
                    onderwerpen = onderwerpen.OrderByDescending(s => s.Omschrijving).ToList();
                    break;
                case "omschrijving":
                    onderwerpen = onderwerpen.OrderBy(s => s.Omschrijving).ToList();
                    break;
            }
        }
    }
}
