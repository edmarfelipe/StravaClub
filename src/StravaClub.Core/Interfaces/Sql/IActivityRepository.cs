using StravaClub.Core.Entities;
using System.Collections.Generic;

namespace StravaClub.Core.Interfaces.Sql
{
	public interface IActivityRepository : IRepository<Activity>
	{
		Activity GetActivityByDate(int athleteId, int month, int year);

		IEnumerable<RankDto> GetYearRank(int year);

		IEnumerable<RankDto> GetMonthRank(int year, int month);
	}
}
