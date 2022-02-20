using AngleSharp.Html.Dom;

namespace ScheduleTelegram.Parsing.Helpers;

public interface IHtmlDownloader
{
    Task<IHtmlDocument> GetDocumentAsync(string url);
}

