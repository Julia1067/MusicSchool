namespace MusicSchool.Models.Domain
{
    public class ConcertProgramModel
    {
        public string Id { get; set; }

        public StudentModel Student { get; set; }
        
        public TeacherModel Teacher { get; set; }

        public string ProgramName { get; set; }
    }
}
