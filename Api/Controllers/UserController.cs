using Data.Dto_s.User;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserService _userService;
        private AccountService _accountService;

        public UserController(UserService userService, AccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            MyUserDto? user = _userService.MyUser(account.Id);

            return View(user);
        }

        /*
        public IActionResult Index()
            {
                //pobieranie userName z ciasteczka
                MyUserDto? myUser = _userService.MyUser("eryczeslaw");

                return View(myUser);
            }
        */
        /*
        [Route("User/{name}")]
        public IActionResult Get(string name)
        {
            GetUserDto? user = _userService.Get(name);

            return View(user);
        }
        */
        
        public IActionResult GetAll()
        {
            List<User> users = _userService.GetAll();
            List<GetUserDto> usersDto = new List<GetUserDto>();

            foreach (var v in users)
            {
                GetUserDto? user = _userService.Get(v.AccountId);
                usersDto.Add(user);

            }

            
            return View(usersDto);
        }
        [Route("/profiles")]
        public IActionResult GetProfiles()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            List<User?> users = _userService.GetProfiles(account.Id);

            List<GetUserDto> usersDto = new List<GetUserDto>();

            foreach (var user in users)
            {
                GetUserDto? userDto = _userService.Get(user.AccountId);
                usersDto.Add(userDto);
            }

            var usersJson = JsonConvert.SerializeObject(usersDto);
            ViewBag.UsersJson = usersJson;

            return View(usersDto);
        }
    }
}