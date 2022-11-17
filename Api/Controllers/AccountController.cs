using Api.Data;
using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.ViewModels.User;
using System.Security.Claims;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            List<Account> accounts = _accountService.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Account account = _accountService.Get(id);

            return View();
        }

        [HttpPost]
        public IActionResult Add(Account account)
        {
            _accountService.Add(account);

            return View();
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAcc = new Account()
                {
                    Email = userRegisterViewModel.Email,
                    Password = userRegisterViewModel.Password,
                };

                _accountService.Add(newAcc);
                ModelState.Clear();
            }
            return View();

        }

        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account acc)
        {
            using (DataContext db = new DataContext())
            {
                var user = _accountService.GetAll()
                .FirstOrDefault(u => u.Email == acc.Email && u.Password == acc.Password);
                if (user != null)
                {
                    // Session["Id"] = usr.Id.ToString();
                    // Session["Email"] = usr.Email.ToString();
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "User"),
                    };


                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong.");
                }
            }
            return View();
        }

        public IActionResult LoggedIn()
        {
            /* if(Session["Id"] != null)
             {
                 return View();
             }
             else
             {
                 return RedirectToAction("Login");
             }*/
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index","Home");
        }
    }
}