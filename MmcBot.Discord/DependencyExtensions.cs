using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MmcBot.Discord.Services;

namespace MmcBot.Discord;

public static class DependencyExtensions
{
    public static IServiceCollection AddDiscord(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DiscordSettings>(config.GetSection("Discord"));
        services.AddSingleton(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Info
        });
        services.AddSingleton<DiscordSocketClient>();
        services.AddSingleton(new InteractionServiceConfig
        {
        });
        services.AddSingleton<InteractionService>(s => 
            new InteractionService(s.GetRequiredService<DiscordSocketClient>().Rest,
            s.GetRequiredService<InteractionServiceConfig>()));
        services.AddHostedService<DiscordHostedService>();
        
        return services;
    }
}