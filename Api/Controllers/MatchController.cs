using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class MatchController : Controller
    {
        private MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
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
    }
}