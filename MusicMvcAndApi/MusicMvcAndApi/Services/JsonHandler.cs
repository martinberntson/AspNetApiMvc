using MusicMvcAndApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicMvcAndApi.Services
{
    internal static class JsonHandler
    {
        internal static void Load()
        {
            Database.Artists = JsonConvert.DeserializeObject<List<Artist>>(
                                File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Artists.json")
                                );
            Database.Albums = JsonConvert.DeserializeObject<List<Album>>(
                                File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Albums.json")
                                );
            Database.Tracks = JsonConvert.DeserializeObject<List<Track>>(
                                File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Tracks.json")
                                );
        }
        internal static void Save()
        {
            Serialize(Database.Artists, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Artists.json");
            Serialize(Database.Albums, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Albums.json");
            Serialize(Database.Tracks, $@"{AppDomain.CurrentDomain.BaseDirectory}\wwwroot\database\Tracks.json");
        }
        private static void Serialize(object list, string path)
        {
            JsonSerializer serializer = new();
            var stream = File.Create(path);
            StreamWriter writer = new(stream);
            serializer.Serialize(writer, list);
            writer.Close();
            stream.Close();
        }
    }
}
