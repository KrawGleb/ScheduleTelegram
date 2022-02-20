using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers;

public class MessageHandler : IMessageHandler
{
    private readonly ILogger<MessageHandler> _logger;
    private readonly ICommandHandler _commandHandler;

    public MessageHandler(
        ILogger<MessageHandler> logger,
        ICommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    public async Task HandleAsync(ITelegramBotClient botClient, Update update)
    {
        _ = update ?? throw new ArgumentNullException(nameof(update));

        _logger.LogInformation("Handle message");

        if (CheckIsMessageCommand(update.Message?.Text))
        {
            await _commandHandler.HandleAsync(botClient, update);
        }
    }

    private bool CheckIsMessageCommand(string? message)
    {
        _ = message ?? throw new ArgumentNullException(nameof(message));

        return
            message.StartsWith("/")
            && !message.Any(ch => ch == ' ');
    }
}

