using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.Enums;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using ScheduleTelegram.Parsing.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers;

public class CallbackQueryHandler : ICallbackQueryHandler
{
    private readonly ILogger _logger;
    private readonly IIcePalaceSchedule _icePalaceSchedule;

    public CallbackQueryHandler(
        ILogger<CallbackQueryHandler> logger,
        IIcePalaceSchedule icePalaceSchedule)
    {
        _logger = logger;
        _icePalaceSchedule = icePalaceSchedule;
    }

    public async Task HandleAsync(ITelegramBotClient botClient, Update update)
    {
        await HandleCallback(botClient, update);
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
        var message = await _icePalaceSchedule.GetScheduleMessageAsync();

        await botClient.SendTextMessageAsync(
            chatId: update.CallbackQuery.Message.Chat.Id,
            text: message.Text,
            parseMode: message.ParseMode);

        _logger.LogInformation("IcePalaceSchedule was sent");
    }

    private async Task HandleGetCinemaScheduleCallback(ITelegramBotClient botClient, Update update)
    {

    }

    private async Task HandleGetDramaTheatreScheduleCallback(ITelegramBotClient botClient, Update update)
    {

    }
}

