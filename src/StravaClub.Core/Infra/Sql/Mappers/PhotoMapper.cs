using DapperExtensions.Mapper;
using StravaClub.Core.Entities;

namespace StravaClub.Core.Infra.Sql.Mappers
{
	public class PhotoMapper : ClassMapper<Photo>
	{
		public PhotoMapper()
		{
			Table("photos");

			Map(x => x.AthleteId).Column("athlete_id");

			AutoMap();
		}
	}
}