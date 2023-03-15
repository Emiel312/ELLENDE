namespace PI4.Models
{
    public class Onderwerp
    {
        public int OnderwerpId { get; set; }
        public string? Omschrijving { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
