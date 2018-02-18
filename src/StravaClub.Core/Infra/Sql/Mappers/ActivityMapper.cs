using DapperExtensions.Mapper;
using StravaClub.Core.Entities;

namespace StravaClub.Core.Infra.Sql.Mappers
{
	public class ActivityMapper : ClassMapper<Activity>
	{
		public ActivityMapper()
		{
			Table("activities");

			Map(x => x.AthleteId).Column("athlete_id");

			AutoMap();
		}
	}
}