using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        public Task<string> RegistrationAsync(RegistrationModel model);
        public Task<string> LoginAsync(LoginModel model);
        public Task LogoutAsync();
    }
}
