using MusicSchool.Models.Domain;

namespace MusicSchool.Repositories.Abstract
{
    public interface IScheduleService
    {
        public List<ClassScheduleModel> GetSchedule(string WeekDay, StudentModel student);

        public List<ExtraClassScheduleModel> GetStudentExtraSchedule(string WeekDay, StudentGroupModel group);

        public List<ClassScheduleModel> GetTeacherSchedule(string WeekDay, TeacherModel teacher);

        public List<ExtraClassScheduleModel> GetExtraTeacherSchedule(string WeekDay, TeacherModel teacher);

        public Task ScheduleUpdate();

        public Task ExtraScheduleUpdate();
    }
}
