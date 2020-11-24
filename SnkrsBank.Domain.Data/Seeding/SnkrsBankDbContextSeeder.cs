using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SnkrsBank.Common;
using SnkrsBank.Domain.Models;
using System;
using System.Linq;

namespace SnkrsBank.Domain.Data.Seeding
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(SnkrsBankDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            Seed(dbContext, userManager, roleManager);
        }

        public static void Seed(SnkrsBankDbContext dbContext, UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            SeedRoles(roleManager);
            //SeedAdmin(userManager);
        }

        private static void SeedAdmin(UserManager<User> userManager)
        {
            User admin = new User
            {
                Firstname = "System",
                Lastname = "Administrator",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                EmailConfirmed = true,
                IsActive = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
            };

            var result = userManager.CreateAsync(admin, "123456").GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }

            var roleResult = userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName).GetAwaiter().GetResult();

            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, roleResult.Errors.Select(e => e.Description)));
            }
        }

        private static void SeedRoles(RoleManager<UserRole> roleManager)
        {
            SeedRole(GlobalConstants.AdministratorRoleName, roleManager);
            SeedRole(GlobalConstants.UserRoleName, roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<UserRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
            if (role == null)
            {
                var result = roleManager.CreateAsync(new UserRole(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
