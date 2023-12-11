namespace MusicSchool.Models.Domain
{
    public class ClassroomModel
    {
        public int Id { get; set; }

        public int ClassroomNumber { get; set; }

        public List<ClassScheduleModel> ClassSchedule { get; set; }

    }
}
