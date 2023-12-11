using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
        }

        public async Task DeleteStudent(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            var student = await databaseContext.Students.FirstOrDefaultAsync(s => s.Email == Email);

            await userManager.DeleteAsync(user);
            databaseContext.Students.Remove(student);

            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteTeacher(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            var teacher = await databaseContext.Teachers.FirstOrDefaultAsync(s => s.Email == Email);

            await userManager.DeleteAsync(user);
            databaseContext.Teachers.Remove(teacher);

            await databaseContext.SaveChangesAsync();
        }

        public string GetCurrentGroup(string Email)
        {
            var student = databaseContext.Students.FirstOrDefault(s => s.Email == Email);

            if (student.StudentGroupId == null)
                return " ";

            var group = databaseContext.StudentGroups.FirstOrDefault(g => g.Id == student.StudentGroupId);

            return group.Name;
        }

        public StudentGroupModel GetCurrentGroup(int Id)
        {
            
            var group = databaseContext.StudentGroups.FirstOrDefault(g => g.Id == Id);

            return group;
        }

        public string GetCurrentPosition(string Email)
        {
            var teacher = databaseContext.Teachers.FirstOrDefault(s => s.Email == Email);

            if (teacher.PositionId == null)
                return " ";

            var position = databaseContext.TeachersPositions.FirstOrDefault(g => g.Id == teacher.PositionId);

            return position.Name;
        }

        public StudentModel GetCurrentStudent(string Email)
        {
            return databaseContext.Students.FirstOrDefault(s => s.Email == Email);
        }

        public StudentModel GetCurrentStudent(int Id)
        {
            return databaseContext.Students.FirstOrDefault(s => s.Id == Id);
        }

        public TeacherModel GetCurrentTeacher(string Email)
        {
            return databaseContext.Teachers.FirstOrDefault(s => s.Email == Email);
        }

        public TeacherModel GetCurrentTeacher(int Id)
        {
            return databaseContext.Teachers.FirstOrDefault(s => s.Id == Id);
        }

        public List<StudentGroupModel> GetStudentGroupList()
        {
            return databaseContext.StudentGroups.ToList();
        }

        public List<StudentModel> GetStudentList()
        {
            return databaseContext.Students.Include(s => s.StudentGroup).ToList();
        }

        public List<StudentModel> GetStudentList(string Groups)
        {
            var group = databaseContext.StudentGroups.Where(g => g.Name == Groups).ToList();
            List<StudentModel> students = new();
            foreach (var item in group)
            {
                students.Add(databaseContext.Students
                    .Where(s => s.StudentGroup == item)
                    .Include(s => s.StudentGroup)
                    .FirstOrDefault());
            } 
            return students;
        }

        public List<TeacherModel> GetTeacherList()
        {
            return databaseContext.Teachers.ToList();
        }

        public List<TeacherModel> GetTeacherList(decimal Salary)
        {
            return databaseContext.Teachers.Where(t => t.Salary == Salary).ToList();
        }

        public List<TeacherModel> GetTeacherList(string Position)
        {
            var positions = databaseContext.TeachersPositions.Where(p => p.Name == Position).ToList();
            List<TeacherModel> teachers = new();
            foreach (var item in positions)
            {
                teachers.Add(databaseContext.Teachers.Where(t => t.Position == item).Include(t => t.Position).FirstOrDefault());
            }
            return teachers;
        }

        public List<TeacherPositionModel> GetTeacherPositionList()
        {
            return databaseContext.TeachersPositions.ToList();
        }

        public async Task UpdateStudentInfo(InfoChangeModel model)
        {
            var student = await databaseContext.Students.Where(s => s.Id == model.Id).FirstOrDefaultAsync();

            var studet_application = await userManager.FindByEmailAsync(student.Email);

            var group = await databaseContext.StudentGroups.FirstOrDefaultAsync(s => s.Name == model.StudentGroupName);

            student.Name = model.Name;
            student.LastName = model.LastName;
            student.Patronymic = model.Patronymic;
            student.StudentGroup = group;
            student.BirthDay = model.BirthDay;

            studet_application.Name = model.Name;
            studet_application.LastName = model.LastName;
            studet_application.Patronymic = model.Patronymic;

            databaseContext.Students.Update(student);
            await userManager.UpdateAsync(studet_application);
            
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateTeacherInfo(InfoChangeModel model)
        {
            var teacher = await databaseContext.Teachers.Where(s => s.Id == model.Id).FirstOrDefaultAsync();

            var teacher_application = await userManager.FindByEmailAsync(teacher.Email);

            var position = await databaseContext.TeachersPositions.FirstOrDefaultAsync(s => s.Name == model.PositionName);

            teacher.Name = model.Name;
            teacher.LastName = model.LastName;
            teacher.Patronymic = model.Patronymic;
            teacher.BirthDay = model.BirthDay;
            teacher.Salary = model.Salary;
            teacher.Position = position;

            teacher_application.Name = model.Name;
            teacher_application.LastName = model.LastName;
            teacher_application.Patronymic = model.Patronymic;

            databaseContext.Teachers.Update(teacher);
            await userManager.UpdateAsync(teacher_application);

            await databaseContext.SaveChangesAsync();
        }

        
    }
}
