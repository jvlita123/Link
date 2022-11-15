using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<User> accounts = _userService.GetAll();

            return View();
        }
    }
}