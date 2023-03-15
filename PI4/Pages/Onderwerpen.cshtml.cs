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


        private VideoSubjectDbContext db;
        public OnderwerpenModel(VideoSubjectDbContext injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet(string sortOrder)
        {
            onderwerpen = db.Onderwerpen.ToList();

        }
    }
}
