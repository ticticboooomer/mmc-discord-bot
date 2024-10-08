using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Service.SuperAdmins;

public interface ISuperAdminService
{
    Task<bool> IsAdminAsync(DiscordUser user);
    Task AddSuperAdminAsync(DiscordUser user);
    Task RemoveSuperAdminAsync(DiscordUser user);
    Task<SuperActionHandlerResponse> HandleSuperAdminCommand(SuperAdminAction action, DiscordUser user);

}