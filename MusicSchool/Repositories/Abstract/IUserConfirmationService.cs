using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IUserConfirmationService
    {
        public List<UnconfirmedUserModel> GetAllUnconfirmedUsers();
        public Task ConfirmAsTeacher(string Email);
        public Task ConfirmAsStudent(string Email);
        public Task LeaveUnconfirmed(string Email);
    }
}
