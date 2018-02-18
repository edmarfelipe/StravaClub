using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using StravaClub.Core.Infra.Http;
using System.Linq;
using Xunit;
using System.IO;

namespace StravaClub.Infra.Test.Crawler
{
	public class StravaParser_AthleteWithOurActivities
	{
		private readonly IDocument _document;
		private readonly StravaParser _parser;

		public StravaParser_AthleteWithOurActivities()
		{
			// Arrange
			_parser = new StravaParser();

			var htmlParser = new HtmlParser();
			_document = htmlParser.Parse(File.ReadAllText("Samples/athlete_without_activities.html"));
		}

		[Fact]
		public void CrawlName_ParseStravaPerfil_ReturnName()
		{
			// Act
			var name = _parser.CrawlName(_document);

			// Assert
			Assert.Equal("Victor Freitas", name);
		}

		[Fact]
		public void CrawlAvatar_ParseStravaPerfil_ReturnAvatar()
		{	
			// Act
			var avatar = _parser.CrawlAvatar(_document);

			// Assert
			Assert.Equal("https://dgalywyr863hv.cloudfront.net/pictures/athletes/25905143/7549816/3/large.jpg", avatar);
		}

		[Fact]
		public void CrawlActivities_ParseActivities_ReturnListOfActivity()
		{
			// Act
			var activity = _parser.CrawlActivity(_document);

			// Assert
			Assert.True(activity.Distance == 0);
			Assert.True(activity.Time == 0);
			Assert.True(activity.Elevation == 0);
		}
	}
}
