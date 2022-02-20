using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.Enums;
using ScheduleTelegram.Bot.Keyboard;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers;

public class CommandHandler : ICommandHandler
{
    private readonly ILogger<CommandHandler> _logger;
    private readonly IKeyboardBuilder _keyboardBuilder;

    public CommandHandler(
        ILogger<CommandHandler> logger,
        IKeyboardBuilder keyboardBuilder)
    {
        _logger = logger;
        _keyboardBuilder = keyboardBuilder;
    }

    public async Task HandleAsync(ITelegramBotClient botClient, Update update)
    {
        _logger.LogInformation("Command handle");

        await HandleCommand(botClient, update);
    }

    private async Task HandleCommand(ITelegramBotClient botClient, Update update)
    {
        switch (update.Message!.Text)
        {
            case BotCommands.Start:
                {
                    await HandleStartCommandAsync(botClient, update);
                    break;
                }
            default:
                {
                    _logger.LogWarning($"Unknown command was received: {update.Message.Text}");
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Нет такой команды");
                    break;
                }

        }
    }

    private async Task HandleStartCommandAsync(ITelegramBotClient botClient, Update update)
    {
        var replyMarkup = _keyboardBuilder.
            WithButtonRow(new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("Ледовый дворец")
                {
                    CallbackData = ScheduleCallback.GetIcePalaceSchedule,
                },
                new InlineKeyboardButton("Кинотеатры")
                {
                    CallbackData = ScheduleCallback.GetCinemaSchedule,
                },
            })
            .WithButtonRow(new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("Театр драмы")
                {
                    CallbackData = ScheduleCallback.GetDramaTheatreSchedule,
                },
            }).Build();

        await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Куда пойдём сегодня?",
            replyMarkup: replyMarkup);
    }
}

