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
        private MatchService _matchService;

        public UserController(UserService userService, AccountService accountService, MatchService matchService)
        {
            _userService = userService;
            _accountService = accountService;
            _matchService = matchService;
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
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            GetUserDto? user = _userService.Get(id);
            GetUserMatchDto? viewModel = new GetUserMatchDto
            {
                loggedID = _userService.GetUserIdByAccountId(account.Id),
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Photos = user.Photos,
                decision = false,
                ProfilePhoto=user.ProfilePhoto,
                Height = user.Height,
                Id = user.Id,
                Localization = user.Localization,
                Name = user.Name,
            };
            Match matchSpecifiedUser = _matchService.GetMatchForSpecifiedUser(viewModel.loggedID, user.Id, 1);
            TempData["match"] = matchSpecifiedUser.Id;
            TempData["user2ID"] = viewModel.Id;
            if (matchSpecifiedUser.StatusId == 1) ViewBag.Message = "Already matched";
            else if (matchSpecifiedUser.StatusId == 4) ViewBag.Message = "Rejected";
            else if ((matchSpecifiedUser.StatusId == 3 && matchSpecifiedUser.FirstUserId == viewModel.loggedID) || (matchSpecifiedUser.StatusId == 2 && matchSpecifiedUser.SecondUserId == viewModel.loggedID)) ViewBag.Message = "Waiting for response";
            else ViewBag.Message = "Match";
            if (user == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(bool Decision)
        {
            Match match = _matchService.Get((int)TempData["match"]);
            int user2ID = (int)TempData["user2ID"];
            _matchService.Update((Match)match, Decision,user2ID);
            return RedirectToAction("Get", new { id = user2ID });
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