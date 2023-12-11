namespace MusicSchool.Models.DTO
{
    public class SetConcertProgramModel
    {
        public int Id { get; set; }

        public string ProgramName { get; set; }

        public int TeacherId { get; set; }

        public int StudentId { get; set; }
    }
}
