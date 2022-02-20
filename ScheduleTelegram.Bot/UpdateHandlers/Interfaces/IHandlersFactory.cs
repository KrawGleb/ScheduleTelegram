using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using Telegram.Bot.Types.Enums;

namespace ScheduleTelegram.Bot.UpdateHandlers.Interfaces;

public interface IHandlersFactory
{
    IConcreteHandler GetConcreteHandler(UpdateType updateType);
}

