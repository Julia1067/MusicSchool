using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Domain
{
    public class PriceModel
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public ClassModel Class { get; set; } 

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
