using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Domain
{
    public class PriceModel
    {
        public int Id { get; set; }

        [ForeignKey("ExtraClassId")]
        public ExtraClassModel Class { get; set; } 

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
