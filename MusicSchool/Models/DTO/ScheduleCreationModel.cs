using MusicSchool.Models.Domain;

namespace MusicSchool.Models.DTO
{
    public class ScheduleCreationModel
    {
        public ClassType ClassType { get; set; }

        public int ClassPosition { get; set; }

        public DayOfWeek WeekDay { get; set; }

        public int TeacherId { get; set; }

        public int? StudentId { get; set; }

        public int? StudentGroupId { get; set; }

        public string ClassName { get; set; }

        public int ClassroomId { get; set; }

    }
}
