using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using StravaClub.Core.Infra.Http;
using System.Linq;
using Xunit;
using System.IO;

namespace StravaClub.Infra.Test.Crawler
{
	public class StravaParser_AthleteWithActivities
	{
		private readonly IDocument _document;
		private readonly StravaParser _parser;

		public StravaParser_AthleteWithActivities()
		{
			// Arrange
			_parser = new StravaParser();

			var htmlParser = new HtmlParser();
			_document = htmlParser.Parse(File.ReadAllText("Samples/athlete_with_activities.html"));
		}

		[Fact]
		public void CrawlName_ParseStravaPerfil_ReturnName()
		{
			// Act
			var name = _parser.CrawlName(_document);

			// Assert
			Assert.Equal("Edmar Felipe", name);
		}

		[Fact]
		public void CrawlAvatar_ParseStravaPerfil_ReturnAvatar()
		{	
			// Act
			var avatar = _parser.CrawlAvatar(_document);

			// Assert
			Assert.Equal("https://graph.facebook.com/1703648542995041/picture?height=256&width=256", avatar);
		}

		[Fact]
		public void CrawlActivities_ParseActivities_ReturnListOfActivity()
		{
			// Act
			var activity = _parser.CrawlActivity(_document);

			// Assert
			Assert.True(activity.Distance == 137.3);
			Assert.True(activity.Time == 7.47);
			Assert.True(activity.Elevation == 1555);
		}
	}
}
