using Microsoft.AspNetCore.Mvc;
using MusicMvcAndApi.Security.Services;

namespace MusicMvcAndApi.Controllers
{
    public class HomeController : Controller
    {
        [BasicAuthorization]
        public IActionResult Index()
        {
            return View();
        }
    }
}
