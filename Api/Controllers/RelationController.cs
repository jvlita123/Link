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
            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);

            if (relationViewModel.IsEdit)
            {
                ViewBag.Message = "Edit";
            }
            else
            {
                ViewBag.Message = "Add";
            }

            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult Love(GetRelationViewModel relationViewModel)
        {
            int loveId = _relationService.GetByName("Love").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);

            List<int> preferenceIds = _preferenceService.GetPreferenceIds(relationViewModel);

            if (relationViewModel.IsEdit)
            {
                _relationUserService.Update(userId, loveId, preferenceIds);
            }
            else
            {
                _relationUserService.Create(userId, loveId, preferenceIds);
            }

            ViewBag.Message = "Success";
            return View(relationViewModel);
        }

        [HttpGet]
        public IActionResult Friendship()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Friendship").Id;
            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);

            if (relationViewModel.IsEdit)
            {
                ViewBag.Message = "Edit";
            }
            else
            {
                ViewBag.Message = "Add";
            }

            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult Friendship(GetRelationViewModel relationViewModel)
        {
            int relId = _relationService.GetByName("Friendship").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);

            List<int> preferenceIds = _preferenceService.GetPreferenceIds(relationViewModel);

            if (relationViewModel.IsEdit)
            {
                _relationUserService.Update(userId, relId, preferenceIds);
            }
            else
            {
                _relationUserService.Create(userId, relId, preferenceIds);
            }

            ViewBag.Message = "Success";
            return View(relationViewModel);
        }

        [HttpGet]
        public IActionResult LooseWriting()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Loose writing").Id;
            GetRelationViewModel relationViewModel = _preferenceService.GetPreferences(userId, relId);

            if (relationViewModel.IsEdit)
            {
                ViewBag.Message = "Edit";
            }
            else
            {
                ViewBag.Message = "Add";
            }

            return View(relationViewModel);
        }

        [HttpPost]
        public IActionResult LooseWriting(GetRelationViewModel relationViewModel)
        {
            int relId = _relationService.GetByName("Loose writing").Id;
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);

            List<int> preferenceIds = _preferenceService.GetPreferenceIds(relationViewModel);

            if (relationViewModel.IsEdit)
            {
                _relationUserService.Update(userId, relId, preferenceIds);
            }
            else
            {
                _relationUserService.Create(userId, relId, preferenceIds);
            }

            ViewBag.Message = "Success";
            return View(relationViewModel);
        }
    }
}