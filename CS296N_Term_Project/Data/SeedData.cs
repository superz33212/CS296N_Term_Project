using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CS296N_Term_Project.Models;

namespace CS296n_Term_Project.Data
{
    public static class SeedData
    {
        const string USERNAME = "admin";
        const string PASSWORD = "Secret!123";
        const string ROLE_NAME = "Admin";

        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(ROLE_NAME) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ROLE_NAME));
            }
            // if username doesn't exist, create it and add it to role if (await userManager.FindByNameAsync(username) == null) { User user = new User { UserName = username }; var result = await userManager.CreateAsync(user, password); if (result.Succeeded) {
            if (await userManager.FindByNameAsync(USERNAME) == null)
            {
                var user = new AppUser { UserName = USERNAME };
                var result = await userManager.CreateAsync(user, PASSWORD);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ROLE_NAME);
                }
            }
        }
    }
}
