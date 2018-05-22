using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces.Domain;
using StravaClub.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StravaClub.Core.Domain
{
	public class Rank : IRank
	{
		private const decimal monthlyGoal = 200;
		private const decimal yearlyGoal = 2200;

		public List<RankDto> CalculteRank(IEnumerable<RankDto> rank, bool isYear = false)
		{
			var list = rank.ToList();

			for (int i = 0; i < list.Count; i++)
			{
				var item = list[i];

				item.Possition = i + 1;
				item.Progress = CalculeteProgress(item.Distance, isYear);
				item.DistancePerDay = CalculeteDistancePerDay(item.Distance, isYear);
			}

			return list;
		}

		private decimal CalculeteDistancePerDay(decimal traveled, bool isYear)
		{
			if(isYear)
			{
				return (yearlyGoal - traveled) / DateTime.Now.DaysToEndYear();
			}
			else
			{
				return (monthlyGoal - traveled) / DateTime.Now.DaysToEndMonth();
			}
		}

        private decimal CalculeteProgress(decimal traveled, bool isYear)
        {
            if (isYear)
            {
                return (traveled / yearlyGoal) * 100;
            }
            else
            {
                return (traveled / monthlyGoal) * 100;
            }
        }
    }
}
