using Data.Entities;
using Microsoft.AspNetCore.Mvc;

using Service;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            accounts = _accountService.GetAccounts();

            return View();
        }
    }
}