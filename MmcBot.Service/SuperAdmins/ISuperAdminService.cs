namespace MmcBot.Service.SuperAdmins;

public interface ISuperAdminService
{
    Task<bool> IsAdminAsync(ulong userId);
    Task AddSuperAdminAsync(ulong userId);
    
}