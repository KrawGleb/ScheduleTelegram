using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.UpdateHandlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegram.Bot.UpdateHandlers;

public class CommonUpdateHandler : ICommonUpdateHandler
{
    private readonly ILogger<CommonUpdateHandler> _logger;
    private readonly IHandlersFactory _handlersFactory;

    public CommonUpdateHandler(
        ILogger<CommonUpdateHandler> logger,
        IHandlersFactory handlersFactory)
    {
        _logger = logger;
        _handlersFactory = handlersFactory;
    }

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"New update was received");

        var handler = _handlersFactory.GetConcreteHandler(update.Type);

        handler.HandleAsync(botClient, update);
    }
}

