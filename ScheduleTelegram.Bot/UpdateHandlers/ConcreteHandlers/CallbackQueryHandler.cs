using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.Enums;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers;

public class CallbackQueryHandler : ICallbackQueryHandler
{
    private readonly ILogger _logger;

    public CallbackQueryHandler(ILogger<CallbackQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(ITelegramBotClient botClient, Update update)
    {
        _logger.LogInformation("Handle callback");
    }

    private async Task HandleCallback(ITelegramBotClient botClient, Update update)
    {
        switch (update.CallbackQuery.Data)
        {
            case ScheduleCallback.GetIcePalaceSchedule:
                {
                    await HandleGetIcePalaceScheduleCallback(botClient, update);
                    break;
                }
            case ScheduleCallback.GetCinemaSchedule:
                {
                    await HandleGetCinemaScheduleCallback(botClient, update);
                    break;
                }
            case ScheduleCallback.GetDramaTheatreSchedule:
                {
                    await HandleGetDramaTheatreScheduleCallback(botClient, update);
                    break;
                }
        }
    }

    private async Task HandleGetIcePalaceScheduleCallback(ITelegramBotClient botClient, Update update)
    {

    }

    private async Task HandleGetCinemaScheduleCallback(ITelegramBotClient botClient, Update update)
    {

    }

    private async Task HandleGetDramaTheatreScheduleCallback(ITelegramBotClient botClient, Update update)
    {

    }
}

