using Discord;
using Discord.Interactions;
using Microsoft.Extensions.DependencyInjection;
using MmcBot.Discord.Extensions;
using MmcBot.Service.SuperAdmins;

namespace MmcBot.Discord.Precondition;

public class RequireSuperAdminAttribute : PreconditionAttribute
{
    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
    {
        var superAdminService = services.GetRequiredService<ISuperAdminService>();
        if (await superAdminService.IsAdminAsync(context.User.ToDiscordUser()))
        {
            return PreconditionResult.FromSuccess();
        }
        return PreconditionResult.FromError("You must be a registered super admin to use this command.");
    }
}