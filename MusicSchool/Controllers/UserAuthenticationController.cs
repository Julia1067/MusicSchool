using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Models;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;
using System.Diagnostics;

namespace MusicSchool.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }


        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                if (model.Role == "admin")
                    return RedirectToAction("Display", "Admin");
                else if(model.Role == "student")
                    return RedirectToAction("Display", "Student");
                else if (model.Role == "teacher")
                    return RedirectToAction("Display", "Teacher");
                else
                    return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.StatusMessage;
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this.authService.RegistrationAsync(model);
            TempData["msg"] = result.StatusMessage;
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> AdminRegister()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Name = "Yuliia",
                LastName = "Hapon",
                Patronymic = "Olehivna",
                Password = "Admin@123",
                PasswordConfirm = "Admin@123",
                Role = "admin"
            };
            var result = await authService.RegistrationAsync(model);
            return Ok(result.StatusMessage);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}