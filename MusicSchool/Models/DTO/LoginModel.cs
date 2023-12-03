using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
