using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MusicSchool.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }
    }
}
