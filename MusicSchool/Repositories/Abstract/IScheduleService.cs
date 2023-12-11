using Microsoft.AspNetCore.Mvc.ModelBinding;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IScheduleService
    {
        public Task<ClassScheduleModel[,]> GetStudentSchedule(int Id);

        public Task<ClassScheduleModel[,]> GetTeacherSchedule( int Id);

        public Task ClassCreation(ScheduleCreationModel model);

        public Task ExtraClassCreation(ScheduleCreationModel model);

        public Task ScheduleUpdate();

        public Task ExtraScheduleUpdate();

        public Task<ClassModel[]> GetAllClasses();

        public Task<ClassroomModel[]> GetAllClassroomes();

        public ClassroomModel GetCurrentClassroom(int Id);

        public ClassModel GetCurrentClass(int Id);
    }
}
