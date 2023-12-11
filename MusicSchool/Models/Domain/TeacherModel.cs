using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Domain
{
    public class TeacherModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        public int? PositionId { get; set; }

        public TeacherPositionModel Position { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public List<ClassScheduleModel> ClassSchedule { get; set; }

    }
}
