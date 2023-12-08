using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Domain
{
    public class ExtraClassScheduleModel
    {
        public int Id { get; set; }

        public TeacherModel Teacher { get; set; }

        public StudentGroupModel Group { get; set; }

        public ExtraClassModel Class { get; set; }

        // Властивість типу DateTime для зберігання часу та дати
        public DateTime Fromdt { get; set; }

        // Властивість тільки для читання, яка повертає тільки час
        public TimeSpan From => Fromdt.TimeOfDay;

        // Властивість типу DateTime для зберігання часу та дати
        public DateTime Todt { get; set; }

        // Властивість тільки для читання, яка повертає тільки час
        public TimeSpan To => Todt.TimeOfDay;

        public string WeekDay { get; set; }

        public ClassroomModel Classroom { get; set; }
    }
}
