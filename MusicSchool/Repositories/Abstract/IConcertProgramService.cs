using MusicSchool.Models.Domain;

namespace MusicSchool.Repositories.Abstract
{
    public interface IConcertProgramService
    {
        public List<ConcertProgramModel> ConcertProgram();

        public Task AddToConcertProgram();

        public Task RemoveFromConcertProgram();

        public Task UpdateConcertProgram();
    }
}
