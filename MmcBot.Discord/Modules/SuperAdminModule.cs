using Discord;
using Discord.Interactions;
using MmcBot.Service.SuperAdmins;

namespace MmcBot.Discord.Modules;

public class SuperAdminModule : InteractionModuleBase
{
    private readonly ISuperAdminService _superAdminService;

    public SuperAdminModule(ISuperAdminService superAdminService)
    {
        _superAdminService = superAdminService;
    }
    
    [SlashCommand("superadmin", "Manage SuperAdmin Users")]
    public async Task Add(
        IUser user)
    {
        if (!await _superAdminService.IsAdminAsync(user.Id))
        {
            await _superAdminService.AddSuperAdminAsync(user.Id);
        }
        await RespondAsync($"Added {user.Username} to list of superadmins", ephemeral: true);
    }
}