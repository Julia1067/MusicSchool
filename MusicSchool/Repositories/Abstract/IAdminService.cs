using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IAdminService
    {
        public StudentModel GetCurrentStudent(string Email);

        public StudentModel GetCurrentStudent(int Id);

        public TeacherModel GetCurrentTeacher(string Email);

        public TeacherModel GetCurrentTeacher(int Id);

        public Task UpdateStudentInfo(InfoChangeModel model);

        public Task UpdateTeacherInfo(InfoChangeModel model);

        public string GetCurrentGroup(string Email);

        public StudentGroupModel GetCurrentGroup(int Id);

        public string GetCurrentPosition(string Email);

        public Task DeleteStudent(string Email);

        public Task DeleteTeacher(string Email);

        public List<StudentModel> GetStudentList();

        public List<StudentModel> GetStudentList(int GroupId);

        public List<TeacherModel> GetTeacherList();

        public List<TeacherModel> GetTeacherListSorted();

        public List<TeacherModel> GetTeacherList(int PositionId);

        public List<StudentGroupModel> GetStudentGroupList();

        public List<TeacherPositionModel> GetTeacherPositionList();
    }
}
