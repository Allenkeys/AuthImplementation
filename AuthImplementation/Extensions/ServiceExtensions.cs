using AuthImplementation.Services.Implementations;
using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IInventoryServices, InventoryServices>();
        return services;
    }
}
