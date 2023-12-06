using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IUserConfirmationService
    {
        public List<UnconfirmedUserModel> GetAllUnconfirmedUsers();
        public Task<StatusModel> ConfirmAsTeacher(string Email);
        public Task<StatusModel> ConfirmAsStudent(string Email);
        public Task<StatusModel> LeaveUnconfirmed(string Email);
    }
}
