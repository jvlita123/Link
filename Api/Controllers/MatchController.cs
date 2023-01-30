using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Models.Relation;
using Service.Services;
using Service.Models.Match;

namespace Api.Controllers
{
    public class MatchController : Controller
    {
        private MatchService _matchService;
        private PreferenceService _preferenceService;
        private RelationService _relationService;
        private RelationUserService _relationUserService;

        public MatchController(MatchService matchService, PreferenceService preferenceService, RelationService relationService, RelationUserService relationUserService)
        {
            _matchService = matchService;
            _preferenceService = preferenceService;
            _relationService = relationService;
            _relationUserService = relationUserService;
        }
       
        public IActionResult Index()
        {
            List<Match> accounts = _matchService.GetAll();

            return View();
        }
        public IActionResult Get(int id)
        {
            Match account = _matchService.Get(id);

            return View();
        }
        [HttpGet]
        public IActionResult MatchLove()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Love").Id;
           Match match = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (match == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(match, userId);
            ViewBag.Message = "LoveMatch";
            TempData["match"] = match.Id;
            TempData["user2ID"] = matchView.User2.Id;
            TempData["url"] = 1; // used to correctly refresh page. (the only alternative I thought of was creating 3 functions, but maybe I am retarded)
            return View(matchView);
        }
        [HttpGet]
        public IActionResult MatchFriendship()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Friendship").Id;
          Match match = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (match == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(match,userId);
            ViewBag.Message = "FriendshipMatch";
            TempData["match"] = match.Id;
            TempData["user2ID"] = matchView.User2.Id;
            TempData["url"] = 2;
            return View(matchView);
        }
        [HttpGet]
        public IActionResult MatchLooseWriting()
        {
           int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Loose Writing").Id;
           Match match = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (match == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(match, userId);
            ViewBag.Message = "LooseWritingMatch";
            TempData["match"] = match.Id;
            TempData["user2ID"] = matchView.User2.Id;
            return View(matchView);

        }
        [HttpPost]
        public IActionResult UpdateTrue()
        {
            Match match = _matchService.Get((int)TempData["match"]);
            int user2ID = (int)TempData["user2ID"];
            _matchService.Update((Match)match, true,(int)user2ID);
            if ((int)TempData["url"] == 1) return RedirectToAction("MatchLove");
            if ((int)TempData["url"] == 2) return RedirectToAction ("MatchFriendship");
          return RedirectToAction("MatchLooseWriting"); // page refresh
        }
        [HttpPost]
        public IActionResult UpdateFalse()
        {
            Match match = _matchService.Get((int)TempData["match"]);
            int user2ID = (int)TempData["user2ID"];
            _matchService.Update((Match)match, false, (int)user2ID);
        if ((int)TempData["url"] == 1) return RedirectToAction("MatchLove");
        if ((int)TempData["url"] == 2) return RedirectToAction("MatchFriendship");
        return RedirectToAction("MatchLooseWriting");
        }
    }
}