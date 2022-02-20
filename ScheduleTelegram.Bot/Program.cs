using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleTelegram.Bot;
using ScheduleTelegram.Bot.Keyboard;
using ScheduleTelegram.Bot.UpdateHandlers;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers;
using ScheduleTelegram.Bot.UpdateHandlers.ConcreteHandlers.Interfaces;
using ScheduleTelegram.Bot.UpdateHandlers.Interfaces;
using ScheduleTelegram.Parsing.Helpers;
using ScheduleTelegram.Parsing.Implementations;
using ScheduleTelegram.Parsing.Interfaces;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => RegisterServices(services))
    .Build();

StartPooling(host.Services);

await host.RunAsync();

static void RegisterServices(IServiceCollection services)
{
    services.AddSingleton<IBot, Bot>();

    services.AddTransient<IHtmlDownloader, HtmlDownloader>();
    services.AddTransient<IHandlersFactory, HandlersFactory>();
    services.AddTransient<IKeyboardBuilder, KeyboardBuilder>();

    services.AddScoped<ICommonUpdateHandler, CommonUpdateHandler>();
    services.AddScoped<IMessageHandler, MessageHandler>();
    services.AddScoped<ICommandHandler, CommandHandler>();
    services.AddScoped<ICallbackQueryHandler, CallbackQueryHandler>();

    services.AddScoped<IIcePalaceSchedule, IcePalaceSchedule>();
}

static void StartPooling(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var bot = provider.GetRequiredService<IBot>();
    bot.Start();
}