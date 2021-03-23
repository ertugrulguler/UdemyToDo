using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.Todo.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("ertugrul");
            if (adminUser == null)
            {
                var appUser = new AppUser()
                {
                    Name = "Ertuğrul",
                    Surname = "Güler",
                    UserName = "ertglr61",
                    Email = "ertglr.61@gmail.com"
                };
                await userManager.CreateAsync(appUser, "ertglr61");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
        }
    }
}
