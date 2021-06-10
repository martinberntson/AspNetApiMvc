using MusicMvcAndApi.Models;
using System;
using System.Linq;

namespace MusicMvcAndApi.Services
{
    internal static class UpdateService
    {
        internal static Artist UpdateArtist(int id, string name)
        {
            Artist updatedArtist = new()
            {
                Id = id,
                Name = name
            };
            Database.Artists[Database.Artists.FindIndex(x => x.Id == id)] = updatedArtist;
            JsonHandler.Save();
            return updatedArtist;
        }
        internal static Album UpdateAlbum(int id, AlbumDto album)
        {
            if (Database.Artists.Where(x => x.Id == album.ArtistId).ToList().Count < 1)
                throw new Exception($"Artist with ID {album.ArtistId} not found.");
            Album updatedAlbum = new()
            {
                Id = id,
                Title = album.Title,
                ArtistId = album.ArtistId,
                ReleaseDate = album.ReleaseDate,
                Price = album.Price,
                AverageUserRating = album.AvgUserRating
            };
            Database.Albums[Database.Albums.FindIndex(x => x.Id == id)] = updatedAlbum;
            JsonHandler.Save();
            return updatedAlbum;
        }
        internal static Track UpdateTrack(int id, TrackDto track)
        {
            if (Database.Albums.Where(x => x.Id == track.AlbumId).ToList().Count < 1)
                throw new Exception($"Album with ID {track.AlbumId} not found.");
            Track updatedTrack = new()
            {
                Id = id,
                Title = track.Title,
                AlbumId = track.AlbumId,
                Runtime = track.Runtime,
                FeatArtist = track.FeatArtist
            };
            Database.Tracks[Database.Tracks.FindIndex(x => x.Id == id)] = updatedTrack;
            JsonHandler.Save();
            return updatedTrack;
        }
    }
}
