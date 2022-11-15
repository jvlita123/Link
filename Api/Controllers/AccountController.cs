using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

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
    }
}