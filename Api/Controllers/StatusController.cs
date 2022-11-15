using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
