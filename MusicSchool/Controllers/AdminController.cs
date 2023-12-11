using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserConfirmationService _confirmationService;
        private readonly IAdminService _adminService;
        private readonly IScheduleService _scheduleService;

        public AdminController(IUserConfirmationService confirmationService,
            IAdminService adminService,
            IScheduleService scheduleService)
        {
            _confirmationService = confirmationService;
            _adminService = adminService;
            _scheduleService = scheduleService;
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

        public async Task ConfirmAsTeacher(string Email)
        {
            await _confirmationService.ConfirmAsTeacher(Email);
        }

        public IActionResult StudentList()
        {
            var students =  _adminService.GetStudentList();
            return View(students);
        }

        public IActionResult UpdateStudentInfo(string Email)
        {
            var student = _adminService.GetCurrentStudent(Email);
            var group = _adminService.GetCurrentGroup(Email);
            var changeModel = new InfoChangeModel()
            {
                LastName = student.LastName,
                BirthDay = student.BirthDay,
                Name = student.Name,
                Id = student.Id,
                Patronymic = student.Patronymic,
                StudentGroupName = group
            };

            return View(changeModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudentInfo(InfoChangeModel model)
        {
            await _adminService.UpdateStudentInfo(model);

            TempData["msg"] = "Changes Saved";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult TeacherList()
        {
            var teachers = _adminService.GetTeacherList();
            return View(teachers);
        }

        public IActionResult UpdateTeacherInfo(string Email)
        {
            var teacher = _adminService.GetCurrentTeacher(Email);
            var changeModel = new InfoChangeModel()
            {
                LastName = teacher.LastName,
                BirthDay = teacher.BirthDay,
                Name = teacher.Name,
                Id = teacher.Id,
                Patronymic = teacher.Patronymic,
                Salary = teacher.Salary
            };

            return View(changeModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacherInfo(InfoChangeModel model)
        {
            await _adminService.UpdateTeacherInfo(model);

            TempData["msg"] = "Changes Saved";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpGet]
        public async Task StudentDelete(string Email)
        {
            await _adminService.DeleteStudent(Email);
        }

        [HttpPost]
        public async Task TeacherDelete(string Email)
        {
            await _adminService.DeleteTeacher(Email);
        }

        [HttpGet]
        public IActionResult ClassCreation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClassCreation(ScheduleCreationModel model)
        {
            await _scheduleService.ClassCreation(model);
            TempData["msg"] = "Changes Saved";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult ExtraClassCreation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExtraClassCreation(ScheduleCreationModel model)
        {
            await _scheduleService.ExtraClassCreation(model);
            TempData["msg"] = "Changes Saved";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<IActionResult> StudentClassSchedule(int id)
        {
            var model = await _scheduleService.GetStudentSchedule(id);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TeacherClassSchedule(int id)
        {
            var model = await _scheduleService.GetTeacherSchedule(id);

            return View(model);
        }


    }
}
