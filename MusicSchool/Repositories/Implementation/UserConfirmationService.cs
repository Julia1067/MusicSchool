using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class UserConfirmationService : IUserConfirmationService
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserConfirmationService(DatabaseContext databaseContext, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task ConfirmAsStudent(string Email)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            string role = "student";

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            await userManager.RemoveFromRoleAsync(user, "user");
            await userManager.AddToRoleAsync(user, role);

            StudentModel student = new()
            {
                Name = user.Name,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Email = user.Email
            };

            databaseContext.Students.Add(student);

            await LeaveUnconfirmed(Email);

        }

        public async Task ConfirmAsTeacher(string Email)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            string role = "teacher";

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            await userManager.RemoveFromRoleAsync(user, "user");
            await userManager.AddToRoleAsync(user, role);

            TeacherModel teacher = new()
            {
                Name = user.Name,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Email = user.Email,
                
            };

            databaseContext.Teachers.Add(teacher);

            await LeaveUnconfirmed(Email);

        }

        public async Task LeaveUnconfirmed(string Email)
        {
            var user = databaseContext.UnconfirmedUsers.FirstOrDefault(x => x.Email == Email);
            databaseContext.UnconfirmedUsers.Remove(user);
            await databaseContext.SaveChangesAsync();
        }

        public  List<UnconfirmedUserModel> GetAllUnconfirmedUsers()
        {
            var users = databaseContext.UnconfirmedUsers.ToList();

            return users;
        }
    }
}
