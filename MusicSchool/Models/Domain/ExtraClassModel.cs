namespace MusicSchool.Models.Domain
{
    public class ExtraClassModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ExtraClassScheduleModel> ExtraClassSchedule { get; set; }

        public PriceModel Price { get; set; }
    }
}
