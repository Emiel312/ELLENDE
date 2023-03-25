using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PI4.Data;
using Microsoft.EntityFrameworkCore;
using PI4.Models;

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
        }
        public void OnDelete()
        {

        }
    }
}
