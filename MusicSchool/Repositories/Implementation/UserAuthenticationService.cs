﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;
using System.Security.Claims;

namespace MusicSchool.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DatabaseContext databaseContext;

        public UserAuthenticationService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            DatabaseContext databaseContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.databaseContext = databaseContext;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);

            string status;

            if (user == null)
            {
                status  = "Invalid username";
                return status;
            }

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status = "Invalid password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };
                status = "User logged in successfully";

                //user = await databaseContext.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                //string userId = user.Id;

                model.Role = (from userRole in databaseContext.UserRoles
                                 where userRole.UserId == user.Id
                                 join role in databaseContext.Roles on userRole.RoleId equals role.Id
                                 select role.Name).FirstOrDefault();
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status = "User locked out";
                return status;
            }
            else
            {
                status = "Error on loggin in";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<string> RegistrationAsync(RegistrationModel model)
        {
            string status;
            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                status = "User already exists";
                return status;
            }


            ApplicationUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Name = model.Name,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Email = model.Email,
                EmailConfirmed = true,
            };

            UnconfirmedUserModel unconfirmed = new()
            {
                Name = model.Name,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Email = model.Email
            };

            await databaseContext.UnconfirmedUsers.AddAsync(unconfirmed);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));


            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            if (!result.Succeeded)
            {
                status = "User creation failed";
                return status;
            }

            databaseContext.SaveChanges();
            status = "User has registered successfully";
            return status;
        }
    }
}
