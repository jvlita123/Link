using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserAchievementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
