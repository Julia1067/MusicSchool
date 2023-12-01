using Microsoft.AspNetCore.Identity;

namespace MusicSchool.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }
    }
}
