using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace MusicMvcAndApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float AverageUserRating { get; set; }
        public int Price { get; set; }
        
        [JsonIgnore]
        public int Runtime
        {
            get
            {
                var sum = 0;
                if (Database.Tracks != null)
                {
                    foreach(var item in Database.Tracks.Where(x => x.AlbumId == Id))
                    {
                        sum += item.Runtime;
                    }
                }
                return sum;
            }
        }
        [JsonIgnore]
        public int NumberOfTracks 
        { get
            {
                var sum = 0;
                if (Database.Tracks != null)
                {
                    foreach (var item in Database.Tracks.Where(x => x.AlbumId == Id))
                    {
                        sum++;
                    }
                }
                return sum;
            } 
        }
    }
}
