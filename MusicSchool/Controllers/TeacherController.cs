using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Repositories.Abstract;
using System.Data;

namespace MusicSchool.Controllers
{
    [Authorize(Roles = "teacher")]
    public class TeacherController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public TeacherController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public IActionResult Display()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TeacherClassSchedule(int id)
        {
            var model = await _scheduleService.GetTeacherSchedule(id);

            return View(model);
        }
    }
}
