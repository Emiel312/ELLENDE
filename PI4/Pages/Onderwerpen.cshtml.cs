using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PI4.Data;
using Microsoft.EntityFrameworkCore;
using PI4.Models;
using PI4;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;

namespace PI4.Pages
{
    public class OnderwerpenModel : PageModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [BindProperty]
        public Onderwerp Onderw { get; set; }

        public ActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Request.Form["Onderw.Omschrijving"]))
                return NotFound();

        else
        {
                db.Onderwerpen.Add(Onderw);
                db.SaveChanges();

                return RedirectToPage();
        }
        }

        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (null == id)
            {
                return NotFound();
            }

            var onderwerp = await db.Onderwerpen.FindAsync(id);

            db.Onderwerpen.Remove(onderwerp);

            await db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}