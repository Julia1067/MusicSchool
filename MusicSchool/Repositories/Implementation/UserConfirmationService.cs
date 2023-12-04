using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class UserConfirmationService : IUserConfirmationService
    {
        private readonly DatabaseContext databaseContext;

        public UserConfirmationService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<StatusModel> ConfirmAsStudent()
        {
            throw new NotImplementedException();
        }

        public Task<StatusModel> ConfirmAsTeacher()
        {
            throw new NotImplementedException();
        }

        public async Task<StatusModel> LeaveUnconfirmed(string Email)
        {
            var user = databaseContext.UnconfirmedUsers.FirstOrDefault(x => x.Email == Email);
            databaseContext.UnconfirmedUsers.Remove(user);
            await databaseContext.SaveChangesAsync();
            return new StatusModel() { StatusCode = 1 };
        }

        public  List<UnconfirmedUserModel> GetAllUnconfirmedUsers()
        {
            var users = databaseContext.UnconfirmedUsers.ToList();

            return users;
        }
    }
}
