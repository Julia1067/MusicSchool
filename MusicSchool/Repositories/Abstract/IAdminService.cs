using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IAdminService
    {
        public StudentModel GetCurrentStudent(string Email);

        public TeacherModel GetCurrentTeacher(string Email);

        public Task UpdateStudentInfo(InfoChangeModel model);

        public Task UpdateTeacherInfo(InfoChangeModel model);

        public string GetCurrentGroup(string Email);

        public string GetCurrentPosition(string Email);

        public Task DeleteStudent(string Email);

        public Task DeleteTeacher(string Email);

        public List<StudentModel> GetStudentList();

        public List<StudentModel> GetStudentList(string Groups);

        public List<TeacherModel> GetTeacherList();

        public List<TeacherModel> GetTeacherList(decimal Salary);

        public List<TeacherModel> GetTeacherList(string Position);

        public List<StudentGroupModel> GetStudentGroupList();

        public List<TeacherPositionModel> GetTeacherPositionList();
    }
}
