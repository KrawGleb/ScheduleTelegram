using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegram.Bot.Keyboard;

public class KeyboardBuilder : IKeyboardBuilder
{
    private readonly List<List<InlineKeyboardButton>> _buttonRows;
    private InlineKeyboardMarkup? _keyboard;
    private InlineKeyboardButton? _button;

    public KeyboardBuilder()
    {
        _buttonRows = new List<List<InlineKeyboardButton>>();
    }

    public void WithButton(InlineKeyboardButton button)
    {
        _button = button;
    }

    public KeyboardBuilder WithButtonRow(List<InlineKeyboardButton> row)
    {
        _buttonRows.Add(row);

        return this;
    }

    public InlineKeyboardMarkup Build()
    {
        if (!OnlyOneMarkupTypeSet())
        {
            throw new InvalidOperationException();
        }

        _keyboard = _button is null
            ? new InlineKeyboardMarkup(_buttonRows)
            : new InlineKeyboardMarkup(_button);

        return _keyboard;
    }

    private bool OnlyOneMarkupTypeSet()
    {
        var isSingleButtonSet = _button is not null;
        var isButtonRowsSet = _buttonRows.Count != 0;

        return
            (isButtonRowsSet && !isSingleButtonSet)
            || (isSingleButtonSet && !isButtonRowsSet);
    }
}

