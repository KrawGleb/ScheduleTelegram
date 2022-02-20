using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using ScheduleTelegram.Bot.UpdateHandlers.Interfaces;
using Telegram.Bot.Types.Enums;

namespace ScheduleTelegram.Bot.UpdateHandlers;

public class HandlersFactory : IHandlersFactory
{
    private readonly ILogger<HandlersFactory> _logger;
    private readonly IMessageHandler _messageHandler;
    private readonly ICallbackQueryHandler _callbackQueryHandler;

    public HandlersFactory(
        ILogger<HandlersFactory> logger,
        IMessageHandler messageHandler,
        ICallbackQueryHandler callbackQueryHandler)
    {
        _logger = logger;
        _messageHandler = messageHandler;
        _callbackQueryHandler = callbackQueryHandler;
    }

    public IConcreteHandler GetConcreteHandler(UpdateType updateType)
    {
        return updateType switch
        {
            UpdateType.Message => _messageHandler,
            UpdateType.CallbackQuery => _callbackQueryHandler,
            _ => throw new InvalidOperationException(),
        };
    }
}

