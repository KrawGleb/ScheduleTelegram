using Microsoft.Extensions.Logging;
using ScheduleTelegram.Bot.Helpers;
using ScheduleTelegram.Bot.UpdateHandlers.Interfaces;
using Telegram.Bot;

namespace ScheduleTelegram.Bot;

public class Bot : IBot
{
    private readonly ILogger<Bot> _logger;
    private readonly ICommonUpdateHandler _updateHandler;
    private readonly TelegramBotClient botClient;

    public Bot(
        ILogger<Bot> logger,
        ICommonUpdateHandler updateHandler)
    {
        _logger = logger;
        _updateHandler = updateHandler;

        // TODO: Inject token into constructor
        botClient = new TelegramBotClient("5171366113:AAHSkYaiSXbDNIepJqxEPvZuhEyYZ70Nf4k"); 
    }

    public async Task Start()
    {
        await botClient.ReceiveAsync(_updateHandler);
    }
}

