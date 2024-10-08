using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Service.SuperAdmins;

public interface ISuperAdminService
{
    Task<bool> IsAdminAsync(ulong userId);
    Task AddSuperAdminAsync(ulong userId);
    Task RemoveSuperAdminAsync(ulong userId);
    Task<SuperActionHandlerResponse> HandleSuperAdminCommand(SuperAdminAction action, ulong userId);

}