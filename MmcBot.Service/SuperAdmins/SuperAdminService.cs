using Microsoft.EntityFrameworkCore;
using MmcBot.Data.Context;
using MmcBot.Data.Model;
using MmcBot.Service.SuperAdmins.Model;
using MongoDB.Bson;

namespace MmcBot.Service.SuperAdmins;

public class SuperAdminService : ISuperAdminService
{
    private readonly AppDbContext _dbContext;

    public SuperAdminService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsAdminAsync(ulong userId)
    {
        var foundUser = await _dbContext.SuperAdmins.FirstOrDefaultAsync(x => x.DiscordUserId == userId);
        return foundUser is not null;
    }

    public async Task AddSuperAdminAsync(ulong userId)
    {
        var entity = new SuperAdmin
        {
            Id = ObjectId.GenerateNewId(),
            DiscordUserId = userId
        };
        await _dbContext.SuperAdmins.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveSuperAdminAsync(ulong userId)
    {
        var entity = await _dbContext.SuperAdmins.FirstOrDefaultAsync(x => x.DiscordUserId == userId);
        if (entity is null)
        {
            return;
        }

        _dbContext.SuperAdmins.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<SuperActionHandlerResponse> HandleSuperAdminCommand(SuperAdminAction action, ulong userId)
    {
        switch (action)
        {
            case SuperAdminAction.Add when !await IsAdminAsync(userId):
                await AddSuperAdminAsync(userId);
                return SuperActionHandlerResponse.AddSuccess;
            case SuperAdminAction.Add:
                return SuperActionHandlerResponse.AddUserExists;
            case SuperAdminAction.Remove when await IsAdminAsync(userId):
                await RemoveSuperAdminAsync(userId);
                return SuperActionHandlerResponse.RemoveSuccess;
            case SuperAdminAction.Remove:
                return SuperActionHandlerResponse.RemoveUserNoExists;
            default:
                return SuperActionHandlerResponse.ErrUnexpected;
        }
    }
}