using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MmcBot.Discord.Services;

public class DiscordHostedService(
    DiscordSocketClient client,
    IOptions<DiscordSettings> settings,
    InteractionService interactionService,
    IServiceProvider provider)
    : IHostedService
{
    private readonly DiscordSettings _settings = settings.Value;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await client.LoginAsync(TokenType.Bot, _settings.Token);
        client.Ready += async () =>
        {
            using var scope = provider.CreateScope();
            await interactionService.AddModulesAsync(GetType().Assembly, scope.ServiceProvider);
            foreach (var guild in client.Guilds)
            {
                await interactionService.RegisterCommandsToGuildAsync(guild.Id);
            }
        };
        client.InteractionCreated += async (a) =>
        {
            var ctx = new SocketInteractionContext(client, a);
            await interactionService.ExecuteCommandAsync(ctx, provider);
        };
        await client.StartAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}