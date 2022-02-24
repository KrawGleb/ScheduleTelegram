using Microsoft.Extensions.Logging;
using ScheduleTelegram.Common.Models;
using ScheduleTelegram.Parsing.Interfaces;

namespace ScheduleTelegram.Parsing.Implementations;

public class CinemaSchedule : ICinemaSchedule
{
    private readonly ILogger _logger;

    public CinemaSchedule(ILogger<CinemaSchedule> logger)
    {
        _logger = logger;
    }

    public Task<ScheduleMessage> GetScheduleMessageAsync()
    {
        _logger.LogInformation("Get CinemaSchedule");

        return null;
    }
}

