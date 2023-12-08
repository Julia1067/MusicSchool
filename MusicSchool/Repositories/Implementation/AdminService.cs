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

        public AdminService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task DeleteUser()
        {
            throw new NotImplementedException();
        }

        public List<StudentGroupModel> GetStudentGroupList()
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> GetStudentList()
        {
            return databaseContext.Students.ToList();
        }

        public List<StudentModel> GetStudentList(string Groups)
        {
            var group = databaseContext.StudentGroups.Where(g => g.Name == Groups).ToList();
            List<StudentModel> students = new List<StudentModel>();
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
            List<TeacherModel> teachers = new List<TeacherModel>();
            foreach (var item in positions)
            {
                teachers.Add(databaseContext.Teachers.Where(t => t.Position == item).Include(t => t.Position).FirstOrDefault());
            }
            return teachers;
        }

        public List<TeacherPositionModel> GetTeacherPositionList()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStudentInfo(StudentInfoChangeModel model)
        {
            var student = await databaseContext.Students.Where(s => s.Id == model.Id).FirstOrDefaultAsync();

            var studet_application = await userManager.FindByEmailAsync(student.Email);

            student.Name = model.Name;
            student.LastName = model.LastName;
            student.Patronymic = model.Patronymic;
            student.StudentGroup = model.StudentGroup;
            student.BirthDay = model.BirthDay;

            studet_application.Name = model.Name;
            studet_application.LastName = model.LastName;
            studet_application.Patronymic = model.Patronymic;

            databaseContext.Students.Update(student);
            await userManager.UpdateAsync(studet_application);
            
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateTeacherInfo(TeacherInfoChangeModel model)
        {
            var teacher = await databaseContext.Teachers.Where(s => s.Id == model.Id).FirstOrDefaultAsync();

            teacher.Name = model.Name;
            teacher.LastName = model.LastName;
            teacher.Patronymic = model.Patronymic;
            teacher.BirthDay = model.BirthDay;
            teacher.Salary = model.Salary;
            teacher.Position = model.Position;

            databaseContext.Teachers.Update(teacher);
            await databaseContext.SaveChangesAsync();
        }

        
    }
}
