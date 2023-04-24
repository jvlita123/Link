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
        
        public IActionResult Get(int id)
        {
            GetUserDto? user = _userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        
        
        public IActionResult GetAll()
        {
            List<User> users = _userService.GetAll();
            List<GetUserDto> usersDto = new List<GetUserDto>();

            foreach (var v in users)
            {
                GetUserDto? user = _userService.Get(v.Id);
                usersDto.Add(user);

            }

            
            return View(usersDto);
        }

        [HttpGet]
        [Route("~/User/GetProfiles/{id}")]
        public IActionResult GetProfiles(string id)
        {
            
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);

            int relID = Int32.Parse(id);
            List<User?> users = _userService.GetProfiles(account.Id, relID); //lista userów należacych do danej relacji
            

            List<GetUserDto> usersDto = new List<GetUserDto>();

            foreach (var user in users)
            {
                GetUserDto? userDto = _userService.Get(user.Id);
                usersDto.Add(userDto);
            }

            var usersJson = JsonConvert.SerializeObject(usersDto);
            ViewBag.UsersJson = usersJson;

            return View(usersDto);
        }
    }
}