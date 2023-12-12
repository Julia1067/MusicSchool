using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.DTO
{
    public class SetPricesModel
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ClassName { get; set; }
    }
}
