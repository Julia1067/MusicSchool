using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;
using MusicSchool.Repositories.Implementation;
using System.Runtime.CompilerServices;

namespace MusicSchool.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IConcertProgramService _concertProgramService;
        private readonly IPriceService _priceService;
        private readonly IAdminService _adminService;

        public StudentController(IScheduleService scheduleService,
            IConcertProgramService concertProgramService,
            IPriceService priceService,
            IAdminService adminService)
        {
            _scheduleService = scheduleService;
            _concertProgramService = concertProgramService;
            _priceService = priceService;
            _adminService = adminService;
        }

        public IActionResult Display()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentClassSchedule(int id)
        {
            var model = await _scheduleService.GetStudentSchedule(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult SetConcertProgram(int Id)
        {
            SetConcertProgramModel model = new()
            {
                StudentId = Id,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetConcertProgram(SetConcertProgramModel model)
        {
            await _concertProgramService.AddToConcertProgram(model);
            TempData["msg"] = "Creation succed";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult GetPrices()
        {
            var prices = _priceService.GetAllPrices();
            return View(prices);
        }
    }
}
