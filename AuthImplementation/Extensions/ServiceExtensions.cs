using AuthImplementation.Data.Context;
using AuthImplementation.Model.Entities;
using AuthImplementation.Services.Implementations;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthImplementation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IInventoryServices, InventoryServices>();
        return services;
    }

    public static void AddDbConnecion(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite("Data Source=Database/app.db");
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireDigit = true;
            opt.Password.RequireUppercase = true;
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }
}
