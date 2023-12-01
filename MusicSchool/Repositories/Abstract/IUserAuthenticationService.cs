using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        public Task<StatusModel> RegistrationAsync(RegistrationModel model);
        public Task<StatusModel> LoginAsync(LoginModel model);
        public Task LogoutAsync();
    }
}
