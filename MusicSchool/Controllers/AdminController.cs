using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using System.Data;

namespace MusicSchool.Controllers
{
    //[Authorize/*(Roles = "admin")*/]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _context;

        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Display()
        {
            //IdentityRole role = await _context.Roles.FirstOrDefaultAsync(x => x.NormalizedName == "USER");
            
            //List<IdentityUserRole<string>> userRoles = await _context.UserRoles
            //    .Include(x => x.User)
            //    .Where(x => x.RoleId == role.Id)
            //    .ToListAsync();

            return View();
        }

        public IActionResult UnconfirmedUser()
        {

            return View();
        }
    }
}
