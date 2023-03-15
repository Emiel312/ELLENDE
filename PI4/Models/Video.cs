namespace PI4.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string? Link { get; set; }
        public string? Titel { get; set; }

        public ICollection<Onderwerp> Onderwerpen { get; set; }
    }
}
