using ScheduleTelegram.Common.Models;

namespace ScheduleTelegram.Parsing.Interfaces;

public interface ISchedule
{
    Task<ScheduleMessage> GetScheduleMessageAsync();
}

