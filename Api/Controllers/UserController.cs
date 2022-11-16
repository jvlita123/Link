using Data.Dto_s.User;
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
            //pobieranie userName z ciasteczka
            MyUserDto? myUser = _userService.MyUser("eryczeslaw");

            return View(myUser);
        }

        [Route("User/{name}")]
        public IActionResult Get(string name)
        {
            GetUserDto? user = _userService.Get(name);

            return View(user);
        }
    }
}