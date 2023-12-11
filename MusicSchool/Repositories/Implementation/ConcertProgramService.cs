using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class ConcertProgramService : IConcertProgramService
    {
        private readonly DatabaseContext databaseContext;

        public ConcertProgramService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AddToConcertProgram(SetConcertProgramModel model)
        {
            ConcertProgramModel concertModel = new()
            {
                ProgramName = model.ProgramName,
                StudentId = model.StudentId,
                TeacherId = model.TeacherId
            };

            await databaseContext.ConcertProgram.AddAsync(concertModel);
            await databaseContext.SaveChangesAsync();
        }

        public List<ConcertProgramModel> GetConcertProgram()
        {
            return databaseContext.ConcertProgram.ToList();

        }

        public ConcertProgramModel GetCurrentConcertProgram(int Id)
        {
            return databaseContext.ConcertProgram.FirstOrDefault(p =>  p.Id == Id);
        }

        public async Task RemoveFromConcertProgram(int Id)
        {
            var program = await databaseContext.ConcertProgram.FirstOrDefaultAsync(p => p.Id == Id);
            
            databaseContext.ConcertProgram.Remove(program);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateConcertProgram(SetConcertProgramModel model)
        {
            var program = await databaseContext.ConcertProgram.FirstOrDefaultAsync(p => p.Id == model.Id);

            program.StudentId = model.StudentId;
            program.TeacherId = model.TeacherId;
            program.ProgramName = model.ProgramName;

            databaseContext.ConcertProgram.Update(program);
            await databaseContext.SaveChangesAsync();
        }
    }
}
