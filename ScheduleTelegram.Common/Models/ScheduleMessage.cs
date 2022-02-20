using Telegram.Bot.Types.Enums;

namespace ScheduleTelegram.Common.Models;

public class ScheduleMessage
{
    public string Text { get; set; }
    public ParseMode ParseMode { get; set; } = ParseMode.Markdown;
}

