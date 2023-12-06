using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Repositories.Abstract;
using System.Data;

namespace MusicSchool.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUserConfirmationService _confirmationService;

        public AdminController(DatabaseContext context, IUserConfirmationService confirmationService)
        {
            _context = context;
            _confirmationService = confirmationService;
        }

        
        public IActionResult Display()
        {

            return View();

        }

        [Authorize(Roles = "admin")]
        public IActionResult UnconfirmedUser()
        {

            return View();
        }

        public async Task Delete(string Email)
        {
            await _confirmationService.LeaveUnconfirmed(Email);
        }

        public async Task ConfirmAsStudent(string Email)
        {
            await _confirmationService.ConfirmAsStudent(Email);
        }
    }
}
