using Discord;
using Discord.Interactions;
using MmcBot.Discord.Extensions;
using MmcBot.Discord.Helper;
using MmcBot.Discord.Modules.Choices;
using MmcBot.Discord.Precondition;
using MmcBot.Service.Forum;
using MmcBot.Service.Forum.Model;

namespace MmcBot.Discord.Modules;

public class ForumModule(IForumTrackingService forumTrackingService) : InteractionModuleBase
{
    [RequireSuperAdmin]
    [SlashCommand("forum_tracking", "Manage Forums")]
    public async Task ManageForumTracking(CmdForumTrackingAction action, IForumChannel channel)
    {
        var resp = await forumTrackingService.HandleForumTrackingCommand(channel.ToDiscordChannel(),
            ChoiceMapper.ToCmdSuperAdminAction(action));

        await RespondAsync(GetManageForumTrackingResponse(resp, channel), ephemeral: true);
    }

    private string GetManageForumTrackingResponse(ForumTrackingHandlerResponse resp, IForumChannel channel)
        => resp switch
        {
            ForumTrackingHandlerResponse.TrackSuccess => $"Added [{channel.Name}] to list of tracked forums",
            ForumTrackingHandlerResponse.UntrackSuccess => $"Removed [{channel.Name}] from list of tracked forums",
            _ => "Unexpected Error"
        };
}