using MmcBot.Service.Model;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Service.SuperAdmins;

public interface ISuperAdminService
{
    Task<bool> IsAdminAsync(DiscordUser user, ulong guildId);
    Task<SimpleResponse> AddSuperAdminAsync(DiscordUser user, ulong guildId);
    Task<SimpleResponse> RemoveSuperAdminAsync(DiscordUser user, ulong guildId);

}