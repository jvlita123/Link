using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models.Relation;
using Service.Services;

namespace Api.Controllers
{
    [Authorize]
    public class RelationController : Controller
    {
        private PreferenceService _preferenceService;
        private RelationService _relationService;
        private RelationUserService _relationUserService;

        public RelationController(PreferenceService preferenceService, RelationService relationService, RelationUserService relationUserService)
        {
            _preferenceService = preferenceService;
            _relationService = relationService;
            _relationUserService = relationUserService;
        }

        [HttpGet]
        public IActionResult Love()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Love").Id;
            bool isRelation = _relationUserService.IsRelation(userId, relId); //sprawdzamy czy użytkownik zapisał się do relacji

            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);
            relationViewModel.RelId = relId;
            relationViewModel.IsRelation = isRelation;
            if (isRelation)
            {
                return Redirect("https://localhost:7014/User/GetProfiles/1"); //jeżeli user jest już zapisany do relacji od razu odesłanie do przeglądania profili
            }


            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult Love(GetRelationViewModel relationViewModel)
        {
            int loveId = _relationService.GetByName("Love").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);

                _relationUserService.Create(userId, loveId);
            

            ViewBag.Message = "Success";
            return Redirect("https://localhost:7014/User/GetProfiles/2");
        }

        [HttpGet]
        public IActionResult Friendship()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Friendship").Id;
            bool isRelation = _relationUserService.IsRelation(userId, relId);
            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);
            relationViewModel.RelId = relId;
            relationViewModel.IsRelation = isRelation;
            if (isRelation)
            {
                return Redirect("https://localhost:7014/User/GetProfiles/2");
            }



            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult Friendship(GetRelationViewModel relationViewModel)
        {
            int relId = _relationService.GetByName("Friendship").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);

                _relationUserService.Create(userId, relId);


            ViewBag.Message = "Success";
            return Redirect("https://localhost:7014/User/GetProfiles/2");
        }

        [HttpGet]
        public IActionResult LooseWriting()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Loose writing").Id;
            bool isRelation = _relationUserService.IsRelation(userId, relId);
            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);
            relationViewModel.RelId = relId;
            relationViewModel.IsRelation = isRelation;
            if (isRelation)
            {
                return Redirect("https://localhost:7014/User/GetProfiles/3");
            }



            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult LooseWriting(GetRelationViewModel relationViewModel)
        {
            int relId = _relationService.GetByName("Loose writing").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);


                _relationUserService.Create(userId, relId);
            

            ViewBag.Message = "Success";
            return Redirect("https://localhost:7014/User/GetProfiles/3");
        }
    }
}