using Discord;
using Discord.Interactions;
using MmcBot.Discord.Extensions;
using MmcBot.Discord.Modules.Choices;
using MmcBot.Service.SuperAdmins;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Discord.Modules;

public class SuperAdminModule : InteractionModuleBase
{
    private readonly ISuperAdminService _superAdminService;

    public SuperAdminModule(ISuperAdminService superAdminService)
    {
        _superAdminService = superAdminService;
    }

    [SlashCommand("superadmin", "Manage SuperAdmin Users")]
    public async Task SuperAdmin(
        CmdSuperAdminAction action,
        IUser user)
    {
        var resp = await _superAdminService.HandleSuperAdminCommand(
            ChoiceMapper.ToSuperAdminAction(action), user.ToDiscordUser(), Context.Guild.Id);

        await RespondAsync(GetSuperAdminResponse(resp, user), ephemeral: true);
    }

    private string GetSuperAdminResponse(SuperActionHandlerResponse resp, IUser user) => resp switch
    {
        SuperActionHandlerResponse.AddSuccess => $"Added user: [{user.Username}] to list of Super-Admins",
        SuperActionHandlerResponse.RemoveSuccess => $"Removed user: [{user.Username}] from list of Super-Admins",
        SuperActionHandlerResponse.AddUserExists => $"User: [{user.Username}] already exists in list of Super-Admins",
        SuperActionHandlerResponse.RemoveUserNoExists => $"User: [{user.Username}] does not exist in list of Super-Admins",
        _ => "Unexpected Error"
    };
}