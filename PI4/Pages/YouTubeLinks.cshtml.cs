using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PI4.Data;
using Microsoft.EntityFrameworkCore;
using PI4.Models;
using System.ComponentModel.DataAnnotations;

namespace PI4.Pages
{
    public class YouTubeLinksModel : PageModel
    {
        public IEnumerable<Video> videos { get; set; } = null!;
        public string TitelSort { get; set; }

        private VideoSubjectDbContext db;
        public YouTubeLinksModel(VideoSubjectDbContext injectedContext)
        {
            db = injectedContext;
        }

        [Required(ErrorMessage = "Veld mag niet leeg zijn.")]
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet(string sortOrder)
        {
            videos = db.Videos.OrderBy(s => s.Titel).ToList();
            TitelSort = sortOrder == "titel" ? "titel_desc" : "titel";

            switch (sortOrder)
            {
                case "titel_desc":
                    videos = videos.OrderByDescending(s => s.Titel).ToList();
                    break;
                case "titel":
                    videos = videos.OrderBy(s => s.Titel).ToList();
                    break;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                if (videos != null)
                {
                #pragma warning disable CS8602
                    videos = videos.Where(v =>
                    v.Titel.ToLower()
                           .Contains(SearchString.ToLower())).ToList();
                #pragma warning restore CS8602
                }
            }
        }
        public void OnDelete()
        {

        }

    }
}
