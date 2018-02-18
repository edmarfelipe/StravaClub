using Microsoft.Extensions.Configuration;
using StravaClub.Core;

namespace StravaClub.Web.Utils
{
	public static class ConfigurationHelpers
    {
		public static AppSettings GetAppSettings(this IConfiguration configuration)
		{
			var app = new AppSettings();

			configuration.Bind("AppSettings", app);

			return app;
		}
    }
}
