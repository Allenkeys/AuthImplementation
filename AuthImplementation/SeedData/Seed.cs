using AuthImplementation.Data.Context;
using AuthImplementation.Model.Enums;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.SeedData;

public static class Seed
{
    public static async Task SeedAll(this IApplicationBuilder builder)
    {
        ApplicationDbContext db = builder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        if (db.Roles.Any())
            return;
        await db.Roles.AddRangeAsync(SeedRoles());
        await db.SaveChangesAsync();
    }
    public static IEnumerable<IdentityRole> SeedRoles()
    {
        return new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Name = UserType.Admin.ToStringValue(),
                NormalizedName = UserType.Admin.ToStringValue()!.ToUpper().Normalize()
            },

            new IdentityRole()
            {
                Name = UserType.BackOffice.ToStringValue(),
                NormalizedName = UserType.BackOffice.ToStringValue()!.ToUpper().Normalize()
            },

            new IdentityRole()
            {
                Name = UserType.FrontOffice.ToStringValue(),
                NormalizedName = UserType.FrontOffice.ToStringValue()!.ToUpper().Normalize()
            }
        };
    }
}
