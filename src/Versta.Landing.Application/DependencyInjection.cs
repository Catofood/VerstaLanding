using System.Reflection;
using Versta.Landing.Application.Common.Behaviors;

namespace Versta.Landing.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(thisAssembly);
        });
        services.AddValidatorsFromAssembly(thisAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(thisAssembly);
        return services;
    }
}