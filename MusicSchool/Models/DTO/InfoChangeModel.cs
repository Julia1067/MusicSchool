using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicSchool.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.DTO
{
    public class InfoChangeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        public string StudentGroupName { get; set; }

        public string PositionName { get; set; }

        public DateTime BirthDay { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public StudentGroupModel StudentGroup { get; set; }

        public TeacherPositionModel Position { get; set; }



        

        
    }
}
