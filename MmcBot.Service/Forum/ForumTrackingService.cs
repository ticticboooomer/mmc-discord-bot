using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MmcBot.Data.Context;
using MmcBot.Data.Model;
using MmcBot.Service.Forum.Model;
using MmcBot.Service.Model;
using MongoDB.Bson;

namespace MmcBot.Service.Forum;

public class ForumTrackingService(AppDbContext dbContext, ILogger<ForumTrackingService> logger) : IForumTrackingService
{
    public async Task TrackChannel(DiscordChannel channel)
    {
        logger.LogInformation("Tracking channel {Channel}", channel.Name);
        var entity = new TrackedForum()
        {
            Id = ObjectId.GenerateNewId(),
            ChannelId = channel.Id,
            ChannelName = channel.Name,
            GuildId = channel.GuildId
        };
        
        await dbContext.TrackedForums.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UntrackChannel(DiscordChannel channel)
    {
        logger.LogInformation("Untracking channel {Channel}", channel.Name);
        var entity = await dbContext.TrackedForums.FirstOrDefaultAsync(x => 
            x.ChannelId == channel.Id && x.GuildId == channel.GuildId);
        if (entity is null)
        {
            return;
        }
        
        dbContext.TrackedForums.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ForumTrackingHandlerResponse> HandleForumTrackingCommand(DiscordChannel channel, ForumTrackingAction action)
    {
        logger.LogInformation("Handling forum tracking command {Action}", action.ToString());
        switch (action)
        {
            case ForumTrackingAction.Track:
                await TrackChannel(channel);
                return ForumTrackingHandlerResponse.TrackSuccess;
            case ForumTrackingAction.Untrack:
                await UntrackChannel(channel);
                return ForumTrackingHandlerResponse.UntrackSuccess;
            default:
                return ForumTrackingHandlerResponse.ErrUnexpected;
                
        }
    }
}