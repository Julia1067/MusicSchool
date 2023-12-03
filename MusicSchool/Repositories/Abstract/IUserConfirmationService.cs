using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IUserConfirmationService
    {
        public List<UnconfirmedUserModel> GetAllUnconfirmedUsers();
        public Task<StatusModel> ConfirmAsTeacher();
        public Task<StatusModel> ConfirmAsStudent();
        public Task<StatusModel> LeaveUnconfirmed();
    }
}
