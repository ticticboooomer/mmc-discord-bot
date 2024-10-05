using Discord;
using Discord.Interactions;
using MmcBot.Discord.Helper;

namespace MmcBot.Discord.Interactions;

public class ForumModule : InteractionModuleBase
{
    [SlashCommand("close", "Closes Forum thread")]
    public async Task Close()
    {
        if (Context.Channel is IThreadChannel channel)
        {
            await RespondAsync("Closing Ticket as requested");
            var ch = await ChannelHelper.GetForumChannel(Context, channel.CategoryId.GetValueOrDefault());
            var helpTag = ch.Tags.FirstOrDefault(x => x.Name == "help");
            var completedTag  = ch.Tags.FirstOrDefault(x => x.Name == "COMPLETED");
            await channel.ModifyAsync(x =>
            {
                x.AppliedTags = Optional.Create<IEnumerable<ulong>>([completedTag.Id, 
                    ..channel.AppliedTags.Where(t => t != helpTag.Id && t != completedTag.Id)]);
                x.Archived = true;
                x.Locked = true;
            });
        }
    }
}