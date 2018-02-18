using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Sql;

namespace StravaClub.Core.Infra.Sql
{
	public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
	{
		public PhotoRepository(IAppSettings appSettings) : base(appSettings)
		{
		}
	}
}
