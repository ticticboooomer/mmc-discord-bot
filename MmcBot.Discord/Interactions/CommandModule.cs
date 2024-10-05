using Discord.Interactions;

namespace MmcBot.Discord.Interactions;

public class CommandModule : InteractionModuleBase
{
    [SlashCommand("ping", "Ping Bot")]
    public async Task PingAsync()
    {
        await RespondAsync("Am here chill TF out bish");
    }
}