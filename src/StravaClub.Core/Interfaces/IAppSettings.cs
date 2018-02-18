namespace StravaClub.Core.Interfaces
{
	public interface IAppSettings
	{
		string[] Athletes { get; set; }

		string DatabaseConnectionString { get; set; }
	}
}