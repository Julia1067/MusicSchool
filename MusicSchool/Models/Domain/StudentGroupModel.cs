namespace MusicSchool.Models.Domain
{
    public class StudentGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<StudentModel> Students { get; set; }

        public List<ClassScheduleModel> ExtraClassSchedule { get; set; }
    }
}
