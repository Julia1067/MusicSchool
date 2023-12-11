namespace MusicSchool.Models.Domain
{
    public class ConcertProgramModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public string ProgramName { get; set; }

        public StudentModel Student { get; set; }

        public TeacherModel Teacher { get; set; }
    }
}
