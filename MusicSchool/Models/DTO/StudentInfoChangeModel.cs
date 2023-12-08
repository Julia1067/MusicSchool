using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicSchool.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.DTO
{
    public class StudentInfoChangeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        public StudentGroupModel StudentGroup { get; set; }
    }
}
