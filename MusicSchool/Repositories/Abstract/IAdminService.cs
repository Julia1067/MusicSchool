using MusicSchool.Models.Domain;

namespace MusicSchool.Repositories.Abstract
{
    public interface IAdminService
    {
        public Task UpdateStudentInfo();

        public Task UpdateTeacherInfo();

        public Task DeleteUser();

        public List<StudentModel> GetStudentList();

        public List<StudentModel> GetStudentList(string Groups);

        public Task<TeacherModel> GetTeacherList();

        public Task<TeacherModel> GetTeacherList(decimal Salary);

        public Task<TeacherModel> GetTeacherList(TeacherPositionModel position);
    }
}
