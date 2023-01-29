using Data.Dto_s.User;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class PremiumController : Controller
    {
        private PremiumService _premiumService;

        public PremiumController(PremiumService premiumService)
        {
            _premiumService=premiumService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Premium(){
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            System.Diagnostics.Debug.WriteLine("USERID!!!!!"+userId);
            _premiumService.SetPremium(userId);
            return Redirect("/user");
        }

    }
}