using System.Text;
using AuthImplementation.Data.Context;
using AuthImplementation.Data.Repository;
using AuthImplementation.Model.Entities;
using AuthImplementation.Services.Implementations;
using AuthImplementation.Services.Interfaces;
using AuthImplementation.Services.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AuthImplementation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IInventoryServices, InventoryServices>();
        services.AddScoped<IJwtAuthenticate, JwtAuthenticate>();
        services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
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

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtConfig");

        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]))
                };
            });
    }
}
