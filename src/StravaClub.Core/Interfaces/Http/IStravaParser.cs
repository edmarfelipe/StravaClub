using AngleSharp.Dom;
using StravaClub.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StravaClub.Core.Interfaces.Http
{
	public interface IStravaParser
	{
		Activity CrawlActivity(IDocument document);

		string CrawlAvatar(IDocument document);

		string CrawlName(IDocument document);

		Task<IDocument> GetDocument(string url);
	}
}