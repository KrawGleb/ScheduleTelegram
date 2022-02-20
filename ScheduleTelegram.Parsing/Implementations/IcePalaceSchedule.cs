using AngleSharp.Dom;
using Microsoft.Extensions.Logging;
using ScheduleTelegram.Common.Models;
using ScheduleTelegram.Parsing.Helpers;
using ScheduleTelegram.Parsing.Interfaces;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.Enums;

namespace ScheduleTelegram.Parsing.Implementations;

public class IcePalaceSchedule : IIcePalaceSchedule
{
    private const string _url = "http://www.brest-hockey.by/";
    private readonly ILogger<IcePalaceSchedule> _logger;
    private readonly IHtmlDownloader _htmlDownloader;

    public IcePalaceSchedule(
        ILogger<IcePalaceSchedule> logger,
        IHtmlDownloader htmlDownloader)
    {
        _logger = logger;
        _htmlDownloader = htmlDownloader;
    }

    public async Task<ScheduleMessage> GetScheduleMessageAsync()
    {
        var message = new ScheduleMessage()
        {
            Text = await GetMessageTextAsync(),
            ParseMode = ParseMode.Html,
        };

        return message;
    }

    private async Task<string> GetMessageTextAsync()
    {
        _logger.LogInformation("Start receiving IcePalaceTimelist");

        var document = await _htmlDownloader.GetDocumentAsync(_url);

        var timelistTableRows = document
            .QuerySelector("table.table-scating")
            .QuerySelectorAll("tr");

        string messageWithTimetable = "";

        foreach (var row in timelistTableRows)
        {
            messageWithTimetable += GetTimelistRowText(row);
        }

        _logger.LogInformation("IcePalaceTimelist received");

        return messageWithTimetable;
    }

    private string GetTimelistRowText(IElement row)
    {
        var dateAndTime = row.QuerySelectorAll("td");
        var dateTd = dateAndTime.FirstOrDefault();
        var timeTd = dateAndTime.LastOrDefault();

        var date = dateTd?.TextContent?.Trim();
        var time = timeTd?.TextContent?.Trim();

        if (date is not null && time is not null && ValidateTimeString(time))
        {
            return $"{date} : <b>{time}</b> \n\n";
        }

        return string.Empty;
    }

    private bool ValidateTimeString(string time)
    {
        var regex = new Regex(@"[0-2]{0,1}[0-5]:[0-5]\d"); // 12:00, 1:34

        return regex.IsMatch(time);
    }
}

