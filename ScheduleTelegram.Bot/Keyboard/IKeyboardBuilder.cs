using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegram.Bot.Keyboard;

public interface IKeyboardBuilder
{
    void WithButton(InlineKeyboardButton button);
    KeyboardBuilder WithButtonRow(List<InlineKeyboardButton> row);
    InlineKeyboardMarkup Build();
}

