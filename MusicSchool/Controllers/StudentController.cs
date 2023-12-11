using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public StudentController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
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
    }
}
