using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.DTO
{
    public class SetConcertProgramModel
    {
        public int Id { get; set; }

        [Required]
        public string ProgramName { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
