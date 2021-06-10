using System.Linq;

namespace MusicMvcAndApi.Services
{
    internal static class NextIdService
    {
        internal static int ArtistId()
        {
            return (Models.Database.Artists.Aggregate((x, y) => x.Id > y.Id ? x : y).Id + 1);
        }
        internal static int AlbumId()
        {
            return (Models.Database.Albums.Aggregate((x, y) => x.Id > y.Id ? x : y).Id + 1);
        }
        internal static int TrackId()
        {
            return (Models.Database.Albums.Aggregate((x, y) => x.Id > y.Id ? x : y).Id + 1);
        }
    }
}
