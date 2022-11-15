using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class MatchHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
