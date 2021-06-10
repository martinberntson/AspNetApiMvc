using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Models;
using MusicMvcAndApi.Services;
using System.Linq;

namespace MusicMvcAndApi.Controllers
{
    public class ArtistApiController : Controller
    {
        [Route("~/Artist/Api")]
        public IActionResult Index()
        {
            return Ok(Database.Artists);
        }
        [Route("~/Artist/Api/{id}")]
        public IActionResult Index(int id)
        {
            return Ok(Database.Artists.Where(x => x.Id == id).FirstOrDefault());
        }
        [Route("~/Artist/Api/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(DeletionService.DeleteArtistById(id));
        }
        [Route("~/Artist/Api/Create/{name}")]
        public IActionResult Create(string name)
        {
            return Ok(CreationService.NewArtist(name));
        }
        [Route("~/Artist/Api/Update/{id}&{name}")]
        public IActionResult Update(int id, string name)
        {
            return Ok(UpdateService.UpdateArtist(id, name));
        }
    }
}
