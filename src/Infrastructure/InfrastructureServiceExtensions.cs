using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<FormDbContext>(options =>  options.UseNpgsql(connectionString));
        return services;
    }
}