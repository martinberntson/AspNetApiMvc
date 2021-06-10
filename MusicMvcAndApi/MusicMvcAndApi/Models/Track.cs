namespace MusicMvcAndApi.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public int Runtime { get; set; }
        public string FeatArtist { get; set; } = null;

    }
}
