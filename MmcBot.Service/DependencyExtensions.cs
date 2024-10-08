using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MmcBot.Service.Forum;
using MmcBot.Service.SuperAdmins;

namespace MmcBot.Service;

public static class DependencyExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ISuperAdminService, SuperAdminService>();
        services.AddTransient<IForumTrackingService, ForumTrackingService>();

        return services;
    }
}