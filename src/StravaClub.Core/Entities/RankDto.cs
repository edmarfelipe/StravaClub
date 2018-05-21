namespace StravaClub.Core.Entities
{
	public class RankDto
	{
		public int Possition { get; set; }

		public int AthleteId { get; set; }

		public decimal Time { get; set; }

		public decimal Elevation { get; set; }

		public decimal Distance { get; set; }

		public string Name { get; set; }

		public string Avatar { get; set; }

		public decimal Progress { get; set; }

		public decimal DistancePerDay { get; set; }
	}
}
