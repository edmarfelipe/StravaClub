using DapperExtensions.Mapper;
using StravaClub.Core.Entities;

namespace StravaClub.Core.Infra.Sql.Mappers
{
	public class AthleteMapper : ClassMapper<Athlete>
	{
		public AthleteMapper()
		{
			Table("athletes");

			AutoMap();
		}
	}
}
