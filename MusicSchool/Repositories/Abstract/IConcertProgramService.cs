using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IConcertProgramService
    {
        public List<ConcertProgramModel> GetConcertProgram();

        public ConcertProgramModel GetCurrentConcertProgram(int Id);

        public Task AddToConcertProgram(SetConcertProgramModel model);

        public Task RemoveFromConcertProgram(int Id);

        public Task UpdateConcertProgram(SetConcertProgramModel model);
    }
}
