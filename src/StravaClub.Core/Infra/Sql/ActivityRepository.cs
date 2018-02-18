using System.Collections.Generic;
using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Sql;

namespace StravaClub.Core.Infra.Sql
{
	public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
	{
		public ActivityRepository(IAppSettings appSettings) : base(appSettings)
		{
		}

		public Activity GetActivityByDate(int athleteId, int month, int year)
		{
			var query = @"
				select * from activities 
				where athlete_id = @AthleteId and month = @Month and year = @Year 
				limit 1
			";

			return QueryFirstOrDefault<Activity>(query, new { AthleteId = athleteId, Month = month, Year = year });
		}

		public IEnumerable<RankDto> GetYearRank(int year)
		{
			var query = @"
				Select
				  at.name,
				  at.avatar,
				  sum(ac.distance) as distance,
				  sum(ac.time) as time,
				  sum(ac.elevation) as elevation
				From athletes as at
				Inner Join activities as ac on at.id = ac.athlete_id
				Where ac.year = @Year
				Group By at.id
				Order By distance desc, time desc, elevation desc
			";

			return Query<RankDto>(query, new { Year = year });
		}

		public IEnumerable<RankDto> GetMonthRank(int year, int month)
		{
			var query = @"				
				Select
				  at.name,
				  at.avatar,
				  ac.distance,
				  ac.time ,
				  ac.elevation
				From athletes as at
				Inner Join activities as ac on at.id = ac.athlete_id
				Where ac.year = @Year and ac.month = @Month
				Order By distance desc, time desc, elevation desc
			";

			return Query<RankDto>(query, new { Year = year, Month = month });
		}
	}
}
