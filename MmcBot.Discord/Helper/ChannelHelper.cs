using Discord;

namespace MmcBot.Discord.Helper;

public class ChannelHelper
{
    public static async Task<IForumChannel?> GetForumChannel(IInteractionContext context, ulong id)
    {
        var channels = await context.Guild.GetForumChannelsAsync();
        var channel = channels.FirstOrDefault(x => x.Id == id);
        return channel;
    }
}