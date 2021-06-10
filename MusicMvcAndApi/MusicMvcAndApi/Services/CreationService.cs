using MusicMvcAndApi.Models;
using System;
using System.Linq;

namespace MusicMvcAndApi.Services
{
    public class CreationService
    {
        internal static Artist NewArtist(string name)
        {
            Artist artist = new()
            {
                Name = name,
                Id = ( NextIdService.ArtistId())
            };
            Database.Artists.Add(artist);
            JsonHandler.Save();
            return artist;
        }
        internal static Album NewAlbum(AlbumDto data)
        {
            if (Database.Artists.Where(x => x.Id == data.ArtistId).ToList().Count < 1) 
                throw new Exception($"Artist with ID {data.ArtistId} not found.");
            Album album = new()
            {
                Id = (NextIdService.AlbumId()),
                Title = data.Title,
                ArtistId = data.ArtistId,
                ReleaseDate = data.ReleaseDate,
                AverageUserRating = data.AvgUserRating,
                Price = data.Price
            };
            Database.Albums.Add(album);
            JsonHandler.Save();
            return album;
        }
        internal static Track NewTrack(TrackDto data)
        {
            if (Database.Albums.Where(x => x.Id == data.AlbumId).ToList().Count < 1)
                throw new Exception($"Album with ID {data.AlbumId} not found.");
            Track track = new()
            {
                Id = (NextIdService.TrackId()),
                Title = data.Title,
                AlbumId = data.AlbumId,
                Runtime = data.Runtime,
                FeatArtist = data.FeatArtist
            };
            Database.Tracks.Add(track);
            JsonHandler.Save();
            return track;
        }
    }
}
