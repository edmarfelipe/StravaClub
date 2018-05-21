using Microsoft.AspNetCore.Mvc;
using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces.Domain;
using StravaClub.Core.Interfaces.Http;
using StravaClub.Core.Interfaces.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StravaClub.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStravaRepository _stravaRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IRank _rank;
        private static DateTime lastUpdate;

        public HomeController(IRank rank, IStravaRepository stravaRepository, IActivityRepository activityRepository)
        {
            _rank = rank;
            _stravaRepository = stravaRepository;
            _activityRepository = activityRepository;
        }

        [Route("/")]
        [Route("/month")]
        [Route("/month/{month}")]
        [Route("/month/{year}/{month}")]
        public IActionResult Rank(int month, int year)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            if (month == 0)
            {
                month = DateTime.Now.Month;
            }

            var rank = _activityRepository.GetMonthRank(year, month);

            Import();

            return View(_rank.CalculteRank(rank));
        }


        [Route("/year")]
        [Route("/year/{year}")]
        public IActionResult RankYear(int year)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            var rank = _activityRepository.GetYearRank(year);

            Import();

            return View("Rank", _rank.CalculteRank(rank, true));
        }

        [Route("/update")]
        public IActionResult Update()
        {
            Import(force: true);

            return View();
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }

        private void Import(bool force = false)
        {
            if (DateTime.Now.Subtract(lastUpdate).TotalMinutes < 1 || force)
            {
                return;
            }

            lastUpdate = DateTime.Now;

            _stravaRepository.Import();
        }
    }
}
