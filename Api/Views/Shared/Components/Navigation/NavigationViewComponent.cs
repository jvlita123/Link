using Data.Dto_s.User;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Models
{
    public class NavigationViewComponent : ViewComponent
    {
        private UserService _userService;
        private AccountService _accountService;

        public NavigationViewComponent(UserService userService, AccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public IViewComponentResult Invoke()
        {
            string userEmail = HttpContext.User.Identity.Name;
            NavUserDto? user = null;
            if (!string.IsNullOrEmpty(userEmail))
            {
                Account account = _accountService.GetByEmail(userEmail);
                user = _userService.GetNavUserDto(account.Id);
            }

            return View(user);
        }
    }
}