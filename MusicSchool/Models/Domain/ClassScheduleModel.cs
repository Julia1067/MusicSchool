using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MusicSchool.Models.Domain
{
    public class ClassScheduleModel
    {
        public int Id { get; set; }

        public ClassType ClassType { get; set; }

        /// <summary>
        /// Fsor example: 1 means 9.00-10.00, 2 means 10.00-11.00 etc.)
        /// </summary>
        public int ClassPosition { get; set; }

        public int WeekDay { get; set; }

        public int TeacherId { get; set; }

        public int? StudentId { get; set; }

        public int? StudentGroupId { get; set; }

        public int ClassId { get; set; }

        public int ClassroomId { get; set; }

        public TeacherModel Teacher { get; set; }

        public StudentModel Student { get; set; }

        public StudentGroupModel StudentGroup { get; set; }

        public ClassModel Class { get; set; }

        public ClassroomModel Classroom { get; set; }
    }
}
