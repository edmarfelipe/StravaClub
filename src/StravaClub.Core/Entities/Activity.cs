namespace StravaClub.Core.Entities
{
	public class Activity
    {
		public int Id { get; set; }

		public int AthleteId { get; set; }

		public double Time { get; set; }

		public double Elevation { get; set; }

		public double Distance { get; set; }

		public int Year { get; set; }

		public int Month { get; set; }
	}
}
