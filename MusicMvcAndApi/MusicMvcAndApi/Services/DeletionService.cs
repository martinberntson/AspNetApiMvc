using MusicMvcAndApi.Models;
using System.Linq;

namespace MusicMvcAndApi.Services
{
    public class DeletionService
    {
        
        internal static Artist DeleteArtistById(int id)
        {
            foreach(var item in Database.Albums.Where(x => x.ArtistId == id))
            {
                Database.Tracks.RemoveAll(x => x.AlbumId == item.Id);
            }
            Database.Albums.RemoveAll(x => x.ArtistId == id);
            Artist artist = Database.Artists.Where(x => x.Id == id).FirstOrDefault();
            Database.Artists.Remove(artist);
            JsonHandler.Save();
            return artist;
        }
        internal static Album DeleteAlbumById(int id)
        {
            Database.Tracks.RemoveAll(x => x.AlbumId == id);
            Album album = Database.Albums.Where(x => x.Id == id).FirstOrDefault();
            Database.Albums.Remove(album);
            JsonHandler.Save();
            return album;
        }
        internal static Track DeleteTrackById(int id)
        {
            Track track = Database.Tracks.Where(x => x.Id == id).FirstOrDefault();
            Database.Tracks.Remove(track);
            JsonHandler.Save();
            return track;
        }
    }
}
