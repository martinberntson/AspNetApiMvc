using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class ArtistController : Controller
    {
        public object JsonService { get; private set; }

        public IActionResult Index()
        {
            return View(Database.Artists);
        }
        [Route("~/Artist/Index/{id}")]
        public IActionResult Index(int id)
        {
            return View("SingleArtist", Database.Artists.Where(x => x.Id == id).FirstOrDefault());
        }
        public IActionResult Delete(int id)
        {
            return View(Database.Artists.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost, Route("~/Artist/Delete/{id}")]
        public IActionResult DeleteArtist(int id)
        {
            DeletionService.DeleteArtistById(id);
            return View(nameof(Index), Database.Artists);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("~/Artist/Create/")]
        public IActionResult CreateArtist(string name)
        {
            CreationService.NewArtist(name);
            return View(nameof(Index), Database.Artists);
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost, Route("~/Artist/Update/")]
        public IActionResult UpdateArtist(int id, string name)
        {
            UpdateService.UpdateArtist(id, name);
            return View(nameof(Index), Database.Artists);
        }
    }
}
