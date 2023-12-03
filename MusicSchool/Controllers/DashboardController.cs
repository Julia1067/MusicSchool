using Microsoft.AspNetCore.Mvc;

namespace MusicSchool.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }

    }
}
