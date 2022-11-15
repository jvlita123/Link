using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ReactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
