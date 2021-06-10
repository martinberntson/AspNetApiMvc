using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Albums);
        }
        [Route("~/Album/Index/{id}")]
        public IActionResult Index(int id)
        {
            return View("SingleAlbum", Database.Albums.Where(x => x.Id == id).FirstOrDefault());
        }
        public IActionResult Delete(int id)
        {
            return View(Database.Albums.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost, Route("~/Album/Delete/{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            DeletionService.DeleteAlbumById(id);
            return View(nameof(Index), Database.Albums);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("~/Album/Create")]
        public IActionResult Create(string title, int artistId, DateTime releaseDate, float avgUserRating, int price)
        {
            AlbumDto newAlbum = new()
            {
                Title = title,
                ArtistId = artistId,
                ReleaseDate = releaseDate,
                AvgUserRating = avgUserRating,
                Price = price
            };
            CreationService.NewAlbum(newAlbum);
            return View(nameof(Index), Database.Albums);
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost, Route("~/Album/Update")]
        public IActionResult Update(int id, string title, int artistId, DateTime releaseDate, float avgUserRating, int price)
        {
            AlbumDto newAlbum = new()
            {
                Title = title,
                ArtistId = artistId,
                ReleaseDate = releaseDate,
                AvgUserRating = avgUserRating,
                Price = price
            };
            UpdateService.UpdateAlbum(id, newAlbum);
            return View(nameof(Index), Database.Albums);
        }
    }
}
