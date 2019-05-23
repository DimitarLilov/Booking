namespace Booking.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Booking.Common;
    using Booking.Data.Models;
    using Booking.Data.Seeding.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(BookingDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<BookingUser>>();

            var user = await userManager.FindByEmailAsync("demo@demo.bg");
            if (user == null)
            {
                BookingUser demoUser = new BookingUser
                {
                    UserName = "demo@demo.bg",
                    Email = "demo@demo.bg",
                    FirstName = "Demo",
                    LastName = "Demo"
                };

                await userManager.CreateAsync(demoUser, "123456");
            }
            var user2 = await userManager.FindByNameAsync("admin@admin.bg");
            if (user2 == null)
            {
                BookingUser adminUserser = new BookingUser
                {
                    UserName = "admin@admin.bg",
                    Email = "admin@admin.bg",
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                IdentityResult result = await userManager.CreateAsync(adminUserser, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUserser, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}