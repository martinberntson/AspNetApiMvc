using MusicMvcAndApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MusicMvcAndApi.Services
{
    public class XmlToJsonConverter
    {
        public static void CreateJsonDatabaseFromXml()
        {
            XmlSerializer xSerializer = new(typeof(Albums));
            Albums xmlAlbums = (Albums)xSerializer.Deserialize(File.Open($@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\AlbumData.xml", FileMode.Open));

            List<Artist> artistList = ExtractArtists(xmlAlbums);
            List<Album> albumList = ConvertAlbums(xmlAlbums, artistList);
            List<Track> trackList = ConvertTracks(xmlAlbums, albumList);

            JsonSerializer jSerializer = new();
            Serialize(artistList, jSerializer, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Artists.json");
            Serialize(albumList, jSerializer, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Albums.json");
            Serialize(trackList, jSerializer, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Tracks.json");
        }

        private static List<Track> ConvertTracks(Albums xmlAlbums, List<Album> albumList)
        {
            List<Track> trackList = new();
            int trackId = 0;
            foreach (var item in xmlAlbums.Album)
            {
                foreach (var track in item.Track)
                {
                    trackList.Add(new()
                    {
                        Id = trackId,
                        Title = track.Title,
                        AlbumId = albumList.Where(x => x.Title == item.Title).FirstOrDefault().Id,
                        Runtime = RuntimeConverter(track.Runtime),
                        FeatArtist = track.FeatArtist
                    });
                    trackId++;
                }
            }

            return trackList;
        }

        private static List<Album> ConvertAlbums(Albums xmlAlbums, List<Artist> artistList)
        {
            List<Album> albumList = new();
            int albumId = 0;
            foreach (var item in xmlAlbums.Album)
            {
                Album album = new()
                {
                    Title = item.Title,
                    ArtistId = artistList.Where(x => x.Name == item.Artist).FirstOrDefault().Id,
                    ReleaseDate = item.ReleaseDate,
                    AverageUserRating = (float)item.AverageUserRating,
                    Price = item.Price,
                    Id = albumId
                };
                albumId++;

                albumList.Add(album);
            }

            return albumList;
        }

        private static List<Artist> ExtractArtists(Albums xmlAlbums)
        {
            List<Artist> artistList = new();
            int artistId = 0;
            foreach (var item in xmlAlbums.Album)
            {
                Artist artist = new()
                {
                    Name = item.Artist
                };
                if (!artistList.Where(x => x.Name == artist.Name).Any())
                {
                    artist.Id = artistId;
                    artistId++;
                    artistList.Add(artist);
                }
            }

            return artistList;
        }

        private static void Serialize(object list, JsonSerializer jSerializer, string path)
        {
            var stream = File.Create(path);
            StreamWriter writer = new(stream);
            jSerializer.Serialize(writer, list);
            writer.Close();
            stream.Close();
        }

        private static int RuntimeConverter(string runtime)
        {
            string[] split = runtime.Split(":");
            int time = 0;
            time += (Convert.ToInt32(split[0]) * 60);
            time += Convert.ToInt32(split[1]);
            return time;
        }
    }
}
