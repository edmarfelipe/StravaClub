using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Http;
using StravaClub.Core.Interfaces.Sql;
using System;
using System.Threading.Tasks;

namespace StravaClub.Core.Infra.Http
{
	public class StravaRepository : IStravaRepository
	{
		private readonly IStravaParser _stravaParser;
		private readonly IAthleteRepository _athleteRepository;
		private readonly IActivityRepository _activityRepository;
		private readonly IPhotoRepository _photoRepository;
		private readonly IAppSettings _appSettings;

		public StravaRepository(
			IStravaParser stravaParser,
			IAthleteRepository athleteRepository,
			IActivityRepository activityRepository,
			IPhotoRepository photoRepository,
			IAppSettings appSettings)
		{
			_stravaParser = stravaParser;
			_athleteRepository = athleteRepository;
			_activityRepository = activityRepository;
			_photoRepository = photoRepository;
			_appSettings = appSettings;
		}

		public async Task<(Athlete, Activity)> Get(string url)
		{
			var athlete = new Athlete();
			var activity = new Activity();

			var document = await _stravaParser.GetDocument(url);

			if (document is null)
			{
				return (athlete, activity);
			}

			athlete.Url = url;
			athlete.Avatar = _stravaParser.CrawlAvatar(document);
			athlete.Name = _stravaParser.CrawlName(document);
			activity = _stravaParser.CrawlActivity(document);

			return (athlete, activity);
		}

		public int SaveAthlete(Athlete athlete)
		{
			if (athlete is null)
			{
				return 0;
			}

			var currentAthlete = _athleteRepository.GetByUrl(athlete.Url);

			if (currentAthlete is null)
			{
				athlete.Id = _athleteRepository.Insert(athlete);
			}
			else
			{
				athlete.Id = currentAthlete.Id;

				_athleteRepository.Update(athlete);
			}

			return athlete.Id;
		}

		public void SaveActivity(Activity activity)
		{
			if (activity is null)
			{
				return;
			}

			activity.Year = DateTime.Now.Year;
			activity.Month = DateTime.Now.Month;

			var currentActivity = _activityRepository.GetActivityByDate(activity.AthleteId, activity.Month, activity.Year);

			if (currentActivity is null)
			{
				_activityRepository.Insert(activity);
			}
			else
			{
				activity.Id = currentActivity.Id;

				_activityRepository.Update(activity);
			}
		}

		public async void Import()
		{
			foreach (var item in _appSettings.Athletes)
			{
				var (athlete, activity) = await Get(item);

				if (athlete is null)
				{
					continue;
				}

				var athleteId = SaveAthlete(athlete);

				if (activity is null)
				{
					continue;
				}

				activity.AthleteId = athleteId;

				SaveActivity(activity);
			}
		}
	}
}
