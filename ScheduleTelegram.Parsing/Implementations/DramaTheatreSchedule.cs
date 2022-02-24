using Microsoft.Extensions.Logging;
using ScheduleTelegram.Common.Models;
using ScheduleTelegram.Parsing.Interfaces;

namespace ScheduleTelegram.Parsing.Implementations;

public class DramaTheatreSchedule : IDramaTheatreSchedule
{
    private readonly ILogger _logger;

    public DramaTheatreSchedule(Logger<DramaTheatreSchedule> logger)
    {
        _logger = logger;
    }

    public Task<ScheduleMessage> GetScheduleMessageAsync()
    {
        _logger.LogInformation("Get DramaTheatreSchedule");

        return null;
    }
}

