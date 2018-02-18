using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using StravaClub.Core.Entities;
using StravaClub.Core.Interfaces.Http;
using StravaClub.Core.Utils;

namespace StravaClub.Core.Infra.Http
{
	public class StravaParser : IStravaParser
	{
		/// <summary>
		/// Get the page from the given url
		/// </summary>
		/// <param name="url">Page url</param>
		/// <returns>Document</returns>
		public async Task<IDocument> GetDocument(string url)
		{
			var config = Configuration.Default.WithDefaultLoader();

			return await BrowsingContext.New(config).OpenAsync(url);
		}

		public string CrawlName(IDocument document)
		{
			var content = document.QuerySelector(".athlete-profile h1");

			if(content == null)
			{
				return string.Empty;
			}

			return content.TextContent;
		}

		public string CrawlAvatar(IDocument document)
		{
			var content = document.QuerySelector(".athlete-hero .avatar-athlete img");

			if (content == null)
			{
				return string.Empty;
			}

			return content.GetAttribute("src");
		}

		public Activity CrawlActivity(IDocument document)
		{
			var activity = new Activity();

			var lastMonths = document.QuerySelectorAll("#interval-graph-columns li:last-child .bar");

			if(lastMonths.First().ChildElementCount == 0)
			{
				return activity;
			}

			var items = document.QuerySelectorAll("#activity-totals li");	

			foreach (var item in items)
			{
				var type = item.QuerySelector("div.label").TextContent;
				var rawValue = item.QuerySelector("strong").TextContent;
				var value = rawValue.ExtractNumberFromStrava();

				switch (type)
				{
					case "TIME":
						{
							activity.Time = value;
							break;
						}
					case "DISTANCE":
						{
							activity.Distance = value;
							break;
						}
					case "ELEVATION":
						{
							activity.Elevation = value;
							break;
						}
				}
			}

			return activity;
		}
	}
}
