using Discord;
using Discord.Interactions;
using MmcBot.Discord.Extensions;
using MmcBot.Discord.Modules.Choices;
using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Discord.Modules;

[Group("superadmins", "Super Admin Commands")]
public class SuperAdminModule : InteractionModuleBase
{
    private readonly ISuperAdminService _superAdminService;

    public SuperAdminModule(ISuperAdminService superAdminService)
    {
        _superAdminService = superAdminService;
    }

    [SlashCommand("add", "Add SuperAdmin to list")]
    public async Task Add(IUser user)
    {
        var resp = await _superAdminService.AddSuperAdminAsync(user.ToDiscordUser(), Context.Guild.Id);
        if (resp == SimpleResponse.Success)
        {
            await RespondAsync($"Added user: [{user.Username}] to list of Super-Admins", ephemeral: true);
        }
        else
        {
            await RespondAsync($"User: [{user.Username}] was not added to list of Super-Admins, likely already exists", ephemeral: true);
        }
    }

    [SlashCommand("remove", "Remove SuperAdmin from list")]
    public async Task Remove(IUser user)
    {
        var resp = await _superAdminService.RemoveSuperAdminAsync(user.ToDiscordUser(), Context.Guild.Id);

        if (resp == SimpleResponse.Success)
        {
            await RespondAsync($"Removed User: [{user.Username}] from list of Super-Admins", ephemeral: true);
        }
        else
        {
            await RespondAsync(
                $"User: [{user.Username}] was not removed from list of Super-Admins, likely does not exist");
        }
    }

}