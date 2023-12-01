using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public UserAuthenticationService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        public async Task<StatusModel> LoginAsync(LoginModel model)
        {
            var status = new StatusModel();
            var user = await userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Invalid username";
                return status;
            }

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.StatusMessage = "Invalid password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };
                status.StatusCode = 1;
                status.StatusMessage = "User logged in successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User locked out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.StatusMessage = "Error on loggin in";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<StatusModel> RegistrationAsync(RegistrationModel model)
        {
            var status = new StatusModel();
            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User already exists";
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

            var result = await userManager.CreateAsync(user, model.Password);

            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));


            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User creation failed";
                return status;
            }

            
            status.StatusCode = 1;
            status.StatusMessage = "User has registered successfully";
            return status;
        }
    }
}
