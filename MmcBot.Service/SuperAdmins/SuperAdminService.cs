using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MmcBot.Data.Context;
using MmcBot.Data.Model;
using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins.Model;
using MongoDB.Bson;

namespace MmcBot.Service.SuperAdmins;

public class SuperAdminService(AppDbContext dbContext, 
    ILogger<SuperAdminService> logger) : ISuperAdminService
{
    public async Task<bool> IsAdminAsync(DiscordUser user)
    {
        var foundUser = await dbContext.SuperAdmins.FirstOrDefaultAsync(x => x.DiscordUserId == user.UserId);
        return foundUser is not null;
    }

    public async Task AddSuperAdminAsync(DiscordUser user)
    {
        logger.LogInformation("Adding SuperAdmin to Database");
        var entity = new SuperAdmin
        {
            Id = ObjectId.GenerateNewId(),
            DiscordUserId = user.UserId,
            DiscordUsername = user.Username
        };
        await dbContext.SuperAdmins.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveSuperAdminAsync(DiscordUser user)
    {
        logger.LogInformation("Removing SuperAdmin from Database");
        var entity = await dbContext.SuperAdmins.FirstOrDefaultAsync(x => x.DiscordUserId == user.UserId);
        if (entity is null)
        {
            return;
        }

        dbContext.SuperAdmins.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<SuperActionHandlerResponse> HandleSuperAdminCommand(SuperAdminAction action, DiscordUser user)
    {
        logger.LogInformation("Running SuperAdmin Command Handler");
        switch (action)
        {
            case SuperAdminAction.Add when !await IsAdminAsync(user):
                await AddSuperAdminAsync(user);
                return SuperActionHandlerResponse.AddSuccess;
            case SuperAdminAction.Add:
                return SuperActionHandlerResponse.AddUserExists;
            case SuperAdminAction.Remove when await IsAdminAsync(user):
                await RemoveSuperAdminAsync(user);
                return SuperActionHandlerResponse.RemoveSuccess;
            case SuperAdminAction.Remove:
                return SuperActionHandlerResponse.RemoveUserNoExists;
            default:
                return SuperActionHandlerResponse.ErrUnexpected;
        }
    }
}