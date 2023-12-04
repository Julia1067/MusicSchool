using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.DTO
{
    public class RegistrationModel
    {

        public string Role { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }


    }
}
