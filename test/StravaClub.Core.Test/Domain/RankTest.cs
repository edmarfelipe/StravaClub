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
                    Distance = 120
                },
                new RankDto()
                {
                    AthleteId = 1,
                    Distance = 100
                },
                new RankDto()
                {
                    AthleteId = 3,
                    Distance = 50
                }
            };

            // Act
            var rankResult = rank.CalculteRank(sample);

            // Assert

            var athlete1 = rankResult.Where(x => x.AthleteId == 1).First();
            var athlete2 = rankResult.Where(x => x.AthleteId == 2).First();
            var athlete3 = rankResult.Where(x => x.AthleteId == 3).First();

            Assert.Equal(2, athlete1.Possition);
            Assert.Equal(50, athlete1.Progress);

            Assert.Equal(1, athlete2.Possition);
            Assert.Equal(60, athlete2.Progress);

            Assert.Equal(3, athlete3.Possition);
            Assert.Equal(25, athlete3.Progress);
        }

        [Fact]
        public void CalculteRank_Year_ReturnRank()
        {
            // Arrange
            var rank = new Rank();
            var sample = new List<RankDto>()
            {
                new RankDto()
                {
                    AthleteId = 2,
                    Distance = 1100
                },
                new RankDto()
                {
                    AthleteId = 1,
                    Distance = 1320
                },
                new RankDto()
                {
                    AthleteId = 3,
                    Distance = 550
                }
            };

            // Act
            var rankResult = rank.CalculteRank(sample, true);

            // Assert

            var athlete1 = rankResult.Where(x => x.AthleteId == 1).First();
            var athlete2 = rankResult.Where(x => x.AthleteId == 2).First();
            var athlete3 = rankResult.Where(x => x.AthleteId == 3).First();

            Assert.Equal(2, athlete1.Possition);
            Assert.Equal(60, athlete1.Progress);

            Assert.Equal(1, athlete2.Possition);
            Assert.Equal(50, athlete2.Progress);

            Assert.Equal(3, athlete3.Possition);
            Assert.Equal(25, athlete3.Progress);
        }
    }
}
