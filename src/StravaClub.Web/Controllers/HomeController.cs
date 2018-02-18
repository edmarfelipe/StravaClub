using Microsoft.AspNetCore.Mvc;
using StravaClub.Core.Interfaces.Http;
using StravaClub.Core.Interfaces.Sql;
using System;

namespace StravaClub.Controllers
{
	[Route("[controller]")]
	public class HomeController : Controller
	{
		private readonly IStravaRepository _stravaRepository;
		private readonly IActivityRepository _activityRepository;

		public HomeController(IStravaRepository stravaRepository, IActivityRepository activityRepository)
		{
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

			ViewBag.Goal = 200;

			return View(_activityRepository.GetMonthRank(year, month));
		}

		[Route("/year")]
		[Route("/year/{year}")]
		public IActionResult RankYear(int year)
		{
			if (year == 0)
			{
				year = DateTime.Now.Year;
			}

			ViewBag.Goal = 2000;

			return View("Rank", _activityRepository.GetYearRank(year));
		}

		[Route("/update")]
		public IActionResult Update()
		{
			_stravaRepository.Import();

			return View();
		}

		[Route("/error")]
		public IActionResult Error()
		{
			return View();
		}
	}
}
