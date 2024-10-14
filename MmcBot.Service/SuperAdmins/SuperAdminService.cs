using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MmcBot.Data.Context;
using MmcBot.Data.Model;
using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins.Model;
using MongoDB.Bson;

namespace MmcBot.Service.SuperAdmins;

public class SuperAdminService(
    AppDbContext dbContext,
    ILogger<SuperAdminService> logger) : ISuperAdminService
{
    public async Task<bool> IsAdminAsync(DiscordUser user, ulong guildId)
    {
        return await dbContext.SuperAdmins.AnyAsync(x =>
            x.DiscordUserId == user.UserId && x.GuildId == guildId);
    }

    public async Task<SimpleResponse> AddSuperAdminAsync(DiscordUser user, ulong guildId)
    {
        if (await IsAdminAsync(user, guildId))
        {
            return SimpleResponse.Unchanged;
        }

        logger.LogInformation("Adding SuperAdmin to Database");
        var entity = new SuperAdmin
        {
            Id = ObjectId.GenerateNewId(),
            DiscordUserId = user.UserId,
            DiscordUsername = user.Username,
            GuildId = guildId
        };
        await dbContext.SuperAdmins.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return SimpleResponse.Success;
    }

    public async Task<SimpleResponse> RemoveSuperAdminAsync(DiscordUser user, ulong guildId)
    {
        var entity = await dbContext.SuperAdmins.FirstOrDefaultAsync(x =>
            x.DiscordUserId == user.UserId && x.GuildId == guildId);
        if (entity is null)
        {
            return SimpleResponse.Unchanged;
        }

        logger.LogInformation("Removing SuperAdmin from Database");
        dbContext.SuperAdmins.Remove(entity);
        await dbContext.SaveChangesAsync();
        return SimpleResponse.Success;
    }
}