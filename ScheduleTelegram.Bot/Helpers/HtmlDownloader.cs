using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.Extensions.Logging;

namespace ScheduleTelegram.Bot.Helpers;

public class HtmlDownloader : IHtmlDownloader
{
    private readonly ILogger<HtmlDownloader> _logger;

    public HtmlDownloader(ILogger<HtmlDownloader> logger)
    {
        _logger = logger;
    }

    public async Task<IHtmlDocument> GetDocumentAsync(string url)
    {
        try
        {
            var document = await DownloadAndParseDocumentAsync(url);
            return document;
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to download document: {url}");
            _logger.LogError(e.Message);
            throw;
        }
    }

    private async Task<IHtmlDocument> DownloadAndParseDocumentAsync(string url)
    {
        _logger.LogInformation($"Start downloading and parsing document with URL: {url}");

        using var httpClient = new HttpClient();
        using var stream = await httpClient.GetStreamAsync(url);

        var parser = new HtmlParser();
        var document = await parser.ParseDocumentAsync(stream);

        _logger.LogInformation("Document was successfully dowloaded and parsed");

        return document;
    }
}

