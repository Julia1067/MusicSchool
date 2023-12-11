using MusicSchool.Models.Domain;

namespace MusicSchool.Models.DTO
{
    public class ClassScheduleViewModel
    {
        public Dictionary<int, List<ClassScheduleModel>> SchedulesByPosition { get; set; }
    }
}
