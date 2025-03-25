using AgroVA.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace AgroVA.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            };
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("admin@admin").Result == null)
        {
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "admin@admin",
                Email = "admin@admin",
                NormalizedUserName = "ADMIN@ADMIN",
                NormalizedEmail = "ADMIN@ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = _userManager.CreateAsync(admin, "Admin@123").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, "Admin").Wait();
            }
        }

        if (_userManager.FindByEmailAsync("user@user").Result == null)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "user@user",
                Email = "user@user",
                NormalizedUserName = "USER@USER",
                NormalizedEmail = "USER@USER",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            IdentityResult result = _userManager.CreateAsync(user, "User@123").Result;
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }
    }
}
