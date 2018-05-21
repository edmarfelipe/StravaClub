using StravaClub.Core.Domain;
using StravaClub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StravaClub.Core.Test.Domain
{
	public class RankTest
	{
		[Fact]
		public void CalculteRank_Month_ReturnRank()
		{
			// Arrange
			var rank = new Rank();
			var sample = new List<RankDto>()
			{
				new RankDto()
				{
					AthleteId = 2,
					Distance = 125
				},
				new RankDto()
				{
					AthleteId = 1,
					Distance = 88
				},
				new RankDto()
				{
					AthleteId = 3,
					Distance = 33
				}
			};

			// Act
			var rankResult = rank.CalculteRank(sample);

			// Assert
			Assert.Equal(1, rankResult.Where(x => x.AthleteId == 2).First().Possition);
			Assert.Equal(3, rankResult.Where(x => x.AthleteId == 3).First().Possition);
		}
	}
}
