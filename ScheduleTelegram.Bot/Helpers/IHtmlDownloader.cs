using AngleSharp.Html.Dom;

namespace ScheduleTelegram.Bot.Helpers;

public interface IHtmlDownloader
{
    Task<IHtmlDocument> GetDocumentAsync(string url);
}

