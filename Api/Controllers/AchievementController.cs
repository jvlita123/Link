﻿using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class AchievementController : Controller
    {
        private AchievementService _achievementService;

        public AchievementController(AchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        public IActionResult Index()
        {
            List<Achievement> achievements = _achievementService.GetAll();

            return View();
        }
    }
}