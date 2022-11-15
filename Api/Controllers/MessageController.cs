using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
