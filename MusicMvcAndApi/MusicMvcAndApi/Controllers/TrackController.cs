using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Tracks);
        }
        [Route("~/Track/Index/{id}")]
        public IActionResult Index(int id)
        {
            return View("SingleTrack", Database.Tracks.Where(x => x.Id == id).FirstOrDefault());
        }
        public IActionResult Delete(int id)
        {
            return View(Database.Tracks.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost, Route("~/Track/Delete/{id}")]
        public IActionResult DeleteTrack(int id)
        {
            DeletionService.DeleteTrackById(id);
            return View(nameof(Index), Database.Tracks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("~/Track/Create")]
        public IActionResult Create(string title, int albumId, int runtime, string featArtist)
        {
            TrackDto newTrack = new()
            {
                Title = title,
                AlbumId = albumId,
                Runtime = runtime,
                FeatArtist = featArtist
            };
            CreationService.NewTrack(newTrack);
            return View(nameof(Index), Database.Tracks);
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost, Route("~/Track/Update")]
        public IActionResult Update(int id, string title, int albumId, int runtime, string featArtist)
        {
            TrackDto newTrack = new()
            {
                Title = title,
                AlbumId = albumId,
                Runtime = runtime,
                FeatArtist = featArtist
            };
            UpdateService.UpdateTrack(id, newTrack);
            return View(nameof(Index), Database.Tracks);
        }
    }
}
