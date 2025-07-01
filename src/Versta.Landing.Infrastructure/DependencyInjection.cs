using Versta.Landing.Application.Interfaces;
using Versta.Landing.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Versta.Landing.Infrastructure.Persistence;

namespace Versta.Landing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<OrdersDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IOrdersDbContext>(provider => provider.GetRequiredService<OrdersDbContext>());
        return services;
    }

}