using StravaClub.Core.Entities;

namespace StravaClub.Core.Interfaces.Sql
{
	public interface IAthleteRepository : IRepository<Athlete>
	{
		Athlete GetByUrl(string url);
	}
}
