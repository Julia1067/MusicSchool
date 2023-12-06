namespace MusicSchool.Models.Domain
{
    public class TeacherPositionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherModel> Teachers { get; set; }
    }
}
