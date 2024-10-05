using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MmcBot.Data.Context;

namespace MmcBot.Data;

public static class DependencyExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration config)
    {
        services.AddEntityFrameworkMongoDB();
        services.AddDbContext<AppDbContext>(o =>
            o.UseMongoDB(config.GetValue<string>("MongoDb:ConnectionString")!, 
                config.GetValue<string>("MongoDb:DatabaseName")!));
        return services;
    }
}