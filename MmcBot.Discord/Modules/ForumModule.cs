using Discord;
using Discord.Interactions;
using MmcBot.Discord.Helper;
using MmcBot.Discord.Precondition;

namespace MmcBot.Discord.Modules;

public class ForumModule : InteractionModuleBase
{
    [SlashCommand("close", "Close the thread")]
    public async Task CloseThread()
    {
        
    }

    [RequireSuperAdmin]
    [SlashCommand("forums", "Manage Forums")]
    public async Task ManageForums()
    {
        
    }
}