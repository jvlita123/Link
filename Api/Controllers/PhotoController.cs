using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
