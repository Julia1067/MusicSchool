using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicSchool.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.DTO
{
    public class TeacherInfoChangeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        public TeacherPositionModel Position { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
