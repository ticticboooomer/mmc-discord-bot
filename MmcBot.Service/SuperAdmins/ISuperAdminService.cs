using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Service.SuperAdmins;

public interface ISuperAdminService
{
    Task<bool> IsAdminAsync(DiscordUser user, ulong guildId);
    Task AddSuperAdminAsync(DiscordUser user, ulong guildId);
    Task RemoveSuperAdminAsync(DiscordUser user, ulong guildId);
    Task<SuperActionHandlerResponse> HandleSuperAdminCommand(SuperAdminAction action, DiscordUser user, ulong guildId);

}