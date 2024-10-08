using Discord.Interactions;
using MmcBot.Discord.Precondition;

namespace MmcBot.Discord.Modules;

public class CommandModule : InteractionModuleBase
{
    [SlashCommand("ping", "Ping Bot")]
    public async Task PingAsync()
    {
        await RespondAsync("Am here chill TF out bish");
    }

    [RequireSuperAdmin]
    [SlashCommand("adminping", "ping command which requires superadmin perms")]
    public async Task AdminPing()
    {
        await RespondAsync("Super Admin, I am mr bot at ur service.");
    }
}