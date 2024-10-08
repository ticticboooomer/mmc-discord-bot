using MmcBot.Service.Forum.Model;
using MmcBot.Service.Model;

namespace MmcBot.Service.Forum;

public interface IForumTrackingService
{
    Task TrackChannel(DiscordChannel channel);
    Task UntrackChannel(DiscordChannel channel);
    Task<ForumTrackingHandlerResponse> HandleForumTrackingCommand(DiscordChannel channel, ForumTrackingAction action);
}