using StravaClub.Core.Interfaces;

namespace StravaClub.Core
{
	public class AppSettings : IAppSettings
	{
		public string DatabaseConnectionString { get; set; }

		public string[] Athletes { get; set; }
	}
}