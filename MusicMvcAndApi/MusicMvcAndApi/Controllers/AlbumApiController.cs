using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class AlbumApiController : Controller
    {
        [Route("~/Album/Api")]
        public IActionResult Index()
        {
            return Ok(Database.Albums);
        }
        [Route("~/Album/Api/{id}")]
        public IActionResult Index(int id)
        {
            return Ok(Database.Albums.Where(x => x.Id == id).FirstOrDefault());
        }
        [Route("~/Album/Api/Create/{title}&{artistId}&{releaseDate}&{averageUserRating}&{price}")]
        public IActionResult Create(string title, int artistId, DateTime releaseDate, float avgUserRating, int price)
        {
            AlbumDto albumCreationData = new()
            {
                Title = title,
                ArtistId = artistId,
                ReleaseDate = releaseDate,
                AvgUserRating = avgUserRating,
                Price = price
            };
            return Ok(CreationService.NewAlbum(albumCreationData));
        }
        [Route("~/Album/Api/Create/{id}&{title}&{artistId}&{releaseDate}&{averageUserRating}&{price}")]
        public IActionResult Update(int id, string title, int artistId, DateTime releaseDate, float avgUserRating, int price)
        {
            AlbumDto albumCreationData = new()
            {
                Title = title,
                ArtistId = artistId,
                ReleaseDate = releaseDate,
                AvgUserRating = avgUserRating,
                Price = price
            };
            return Ok(UpdateService.UpdateAlbum(id, albumCreationData));
        }
        [Route("~/Album/Api/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(DeletionService.DeleteAlbumById(id));
        }
    }
}
