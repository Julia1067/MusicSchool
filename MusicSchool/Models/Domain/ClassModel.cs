﻿namespace MusicSchool.Models.Domain
{
    public class ClassModel
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public List<ClassScheduleModel> ClassSchedule { get; set; }

        public int?  PriceId { get; set; }

        public PriceModel Price { get; set; }
    }
}
