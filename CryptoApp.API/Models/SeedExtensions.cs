using Microsoft.AspNetCore.Identity;

namespace CryptoApp.API.Models
{
    public static class SeedExtensions
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                //  Seed roles
                if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
                    roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).Wait();
                if (!roleManager.RoleExistsAsync(UserRoles.AppUser).Result)
                    roleManager.CreateAsync(new IdentityRole(UserRoles.AppUser)).Wait();

                var adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                userManager.CreateAsync(adminUser, "Admin123!").Wait();
            }

            return host;
        }
    }
}
