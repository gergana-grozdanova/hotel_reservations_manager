using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using static HotelReservationsManager.WebConstants;

namespace HotelReservationsManager.Seeding
{
    public class Seeder:ISeeder
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public Seeder(
             ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager
            )
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task PopulateDb()
        {
            await SeedRoles();
            Console.WriteLine("ehoooooooooo");
            await SeedAdministrators();
        }

        private async Task SeedRoles()
        {
            if (context.Roles.Any())
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole() { Name = UserRoleName });         
            await roleManager.CreateAsync(new IdentityRole() { Name = AdminRoleName });
        }

        private async Task SeedAdministrators()
        {
            if (context.Users.Any(u=>u.UserName=="Admin"))
            {
                return;
            }

            var user = new ApplicationUser()
            {
                Email = "admin@hotel.com",
                UserName = "Admin",
                Egn = "0000000000",
                PhoneNumber = "0888121456",
                HiredDate = DateTime.Now,
            };

            await userManager.CreateAsync(user, "Admin.123");

            var admin = await userManager.FindByIdAsync(user.Id);
            Console.WriteLine(admin.UserName);
            await userManager.AddToRoleAsync(admin, AdminRoleName);
        }

    }
}
