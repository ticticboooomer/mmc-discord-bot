using Microsoft.EntityFrameworkCore;
using MmcBot.Data.Context;
using MmcBot.Data.Model;
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
        var foundUser =  await _dbContext.SuperAdmins.AsQueryable().FirstOrDefaultAsync(x => x.DiscordUserId == userId);
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
}