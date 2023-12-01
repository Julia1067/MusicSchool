using Microsoft.AspNetCore.Mvc;

namespace MusicSchool.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Display()
        {
            return View();
        }

    }
}
