using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class TrackApiController : Controller
    {
        [Route("~/Track/Api")]
        public IActionResult Index()
        {
            return Ok(Database.Tracks);
        }
        [Route("~/Track/Api/{id}")]
        public IActionResult Index(int id)
        {
            return Ok(Database.Tracks.Where(x => x.Id == id).FirstOrDefault());
        }
        [Route("~/Track/Api/Create/{title}&{albumId}&{runtime}&{featArtist}")]
        public IActionResult Create(string title, int albumId, int runtime, string featArtist)
        {
            if (featArtist == "null") featArtist = null;
            TrackDto track = new()
            {
                Title = title,
                AlbumId = albumId,
                Runtime = runtime,
                FeatArtist = featArtist
            };
            return Ok(CreationService.NewTrack(track));
        }
        [Route("~/Track/Api/Create/{id}&{title}&{albumId}&{runtime}&{featArtist}")]
        public IActionResult Update(int id, string title, int albumId, int runtime, string featArtist)
        {
            if (featArtist == "null") featArtist = null;
            TrackDto track = new()
            {
                Title = title,
                AlbumId = albumId,
                Runtime = runtime,
                FeatArtist = featArtist
            };
            return Ok(CreationService.NewTrack(track));
        }
        [Route("~/Track/Api/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(DeletionService.DeleteTrackById(id));
        }
    }
}
