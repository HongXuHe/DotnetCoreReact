using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Contract;
using Server.Infrastructure.Implementation;

namespace Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreContext>(option =>
        {
            option.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            //option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IStoreContext>(provider => provider.GetService<StoreContext>());
        services.AddScoped<IActivityRepo, ActivityRepo>();
        return services;
    }
}