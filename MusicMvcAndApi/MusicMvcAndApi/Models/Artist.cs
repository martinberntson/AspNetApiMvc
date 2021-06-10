using System.Linq;
using System.Text.Json.Serialization;

namespace MusicMvcAndApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int AlbumCount
        { 
            get {
                if (Database.Albums != null) return Database.Albums.Where(x => x.ArtistId == Id).ToList().Count;
                return 0;
            }
        }
    }
}
