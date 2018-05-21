using StravaClub.Core.Entities;
using System.Collections.Generic;

namespace StravaClub.Core.Interfaces.Domain
{
	public interface IRank
    {
		List<RankDto> CalculteRank(IEnumerable<RankDto> rank, bool isYear = false);
    }
}
