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
            Match? result = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (result == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(result, userId);
            ViewBag.Message = "LoveMatch";
            return View(matchView);
        }
        [HttpGet]
        public IActionResult MatchFriendship()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("Friendship").Id;
            Match? result = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (result == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(result, userId);
            ViewBag.Message = "FriendshipMatch";
            return View(matchView);
        }
        [HttpGet]
        public IActionResult MatchLooseWriting()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value);
            int relId = _relationService.GetByName("LooseWriting").Id;
            Match? result = _matchService.GetNextMatchForLoggedUser(userId, relId);
            if (result == null) { ViewBag.Message = "No Possible matches"; return View(); }
            MatchViewModel matchView = _matchService.GetMatchViewModel(result, userId);
            ViewBag.Message = "LooseWritingMatch";
            return View(matchView);

        }   
    }
}