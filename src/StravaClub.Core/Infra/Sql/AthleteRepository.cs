using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Sql;

namespace StravaClub.Core.Infra.Sql
{
    public class AthleteRepository : BaseRepository<Athlete>, IAthleteRepository
	{
		public AthleteRepository(IAppSettings appSettings) : base(appSettings)
		{
		}

		public Athlete GetByUrl(string url)
		{
			var query = @"select * from athletes where url = @Url limit 1";

			return QueryFirstOrDefault<Athlete>(query, new { Url = url });
		}
	}
}
