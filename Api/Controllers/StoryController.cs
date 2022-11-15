using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
