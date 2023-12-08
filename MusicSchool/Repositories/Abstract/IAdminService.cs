using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IAdminService
    {
        public Task UpdateStudentInfo(StudentInfoChangeModel model);

        public Task UpdateTeacherInfo(TeacherInfoChangeModel model);

        public Task DeleteUser();

        public List<StudentModel> GetStudentList();

        public List<StudentModel> GetStudentList(string Groups);

        public List<TeacherModel> GetTeacherList();

        public List<TeacherModel> GetTeacherList(decimal Salary);

        public List<TeacherModel> GetTeacherList(string Position);

        public List<StudentGroupModel> GetStudentGroupList();

        public List<TeacherPositionModel> GetTeacherPositionList();
    }
}
