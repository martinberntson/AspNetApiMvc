using System;

namespace MusicMvcAndApi.Models
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float AvgUserRating { get; set; }
        public int Price { get; set; }
    }
}
