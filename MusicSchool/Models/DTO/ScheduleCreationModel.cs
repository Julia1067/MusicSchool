using MusicSchool.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.DTO
{
    public class ScheduleCreationModel
    {
        public ClassType ClassType { get; set; }

        [Required]
        public int ClassPosition { get; set; }

        [Required]
        public DayOfWeek WeekDay { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public int? StudentId { get; set; }

        public int? StudentGroupId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public int ClassroomId { get; set; }

    }
}
