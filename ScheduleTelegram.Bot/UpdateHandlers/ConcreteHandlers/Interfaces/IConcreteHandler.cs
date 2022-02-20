using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;

public interface IConcreteHandler
{
    Task HandleAsync(ITelegramBotClient botClient, Update update);
}

