using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MmcBot.Service.SuperAdmins;

namespace MmcBot.Service;

public static class DependencyExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ISuperAdminService, SuperAdminService>();

        return services;
    }
}