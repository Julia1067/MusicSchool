using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly DatabaseContext databaseContext;

        public ScheduleService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<ClassModel[]> GetAllClasses()
        {
            return await databaseContext.Classes.ToArrayAsync();
        }

        public async Task<ClassroomModel[]> GetAllClassroomes()
        {
            return await databaseContext.Classrooms.ToArrayAsync();
        }

        public ClassroomModel GetCurrentClassroom(int Id)
        {
            return databaseContext.Classrooms.FirstOrDefault(c => c.Id == Id);
        }

        public async Task ClassCreation(ScheduleCreationModel model)
        {
            var @class = await databaseContext.Classes.SingleOrDefaultAsync(x => x.ClassName == model.ClassName);

            ClassScheduleModel classSchedule = new() 
            { 
                StudentId = model.StudentId,
                ClassId = @class.Id,
                ClassroomId = model.ClassroomId,
                ClassPosition = model.ClassPosition,
                StudentGroupId = null,
                ClassType = ClassType.Regular,
                WeekDay = (int)model.WeekDay,
                TeacherId = model.TeacherId,
            };

            await databaseContext.Schedule.AddAsync(classSchedule);
            await databaseContext.SaveChangesAsync();

        }

        public async Task ExtraClassCreation(ScheduleCreationModel model)
        {
            var @class = await databaseContext.Classes.SingleOrDefaultAsync(x => x.ClassName == model.ClassName);

            ClassScheduleModel classSchedule = new()
            {
                StudentId = null,
                ClassId = @class.Id,
                ClassroomId = model.ClassroomId,
                ClassPosition = model.ClassPosition,
                StudentGroupId = model.StudentGroupId,
                ClassType = ClassType.Extra,
                WeekDay = (int)model.WeekDay,
                TeacherId = model.TeacherId,
            };

            await databaseContext.Schedule.AddAsync(classSchedule);
            await databaseContext.SaveChangesAsync();

        }

        public Task ExtraScheduleUpdate()
        {
            throw new NotImplementedException();
        }

        public async Task<ClassScheduleModel[,]> GetStudentSchedule(int Id)
        {
            var student = await databaseContext.Students.FirstOrDefaultAsync(x => x.Id == Id);

            var reg_classes = databaseContext.Schedule.Where(s => s.StudentId == student.Id).ToArray();

            var group = await databaseContext.StudentGroups.FirstOrDefaultAsync(g => g.Id == student.StudentGroupId);

            var extra_classes = databaseContext.Schedule.Where(s => s.StudentGroupId == student.StudentGroupId).ToArray();

            var classes = new List<ClassScheduleModel>();
            classes.AddRange(reg_classes);
            classes.AddRange(extra_classes);

            if (classes.Count == 0)
            {
                ClassScheduleModel[,] nullClassesSchedule = new ClassScheduleModel[5, 5];
                return nullClassesSchedule;
            }

            var maxPos = classes.Max(x => x.ClassPosition);
            maxPos = Math.Max(5, maxPos);

            ClassScheduleModel[,] classesSchedule = new ClassScheduleModel[maxPos, 5]; // 5 days in week

            for (int i = 0; i < maxPos; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var @class = classes.FirstOrDefault(x => x.ClassPosition == (i + 1) && x.WeekDay == (j + 1));  
                    classesSchedule[i, j] = @class;
                }
            }

            return classesSchedule;
        }

        public async Task<ClassScheduleModel[,]> GetTeacherSchedule(int Id)
        {
            var teacher = await databaseContext.Teachers.FirstOrDefaultAsync(x => x.Id == Id);

            var classes = databaseContext.Schedule.Where(s => s.TeacherId == teacher.Id).ToArray();

            if (classes.Length == 0)
            {
                ClassScheduleModel[,] nullClassesSchedule = new ClassScheduleModel[5, 5];
                return nullClassesSchedule;
            }

            var maxPos = classes.Max(x => x.ClassPosition);
            maxPos = Math.Max(5, maxPos);

            ClassScheduleModel[,] classesSchedule = new ClassScheduleModel[maxPos, 5]; // 5 days in week

            for (int i = 0; i < maxPos; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var @class = classes.FirstOrDefault(x => x.ClassPosition == (i + 1) && x.WeekDay == (j + 1));
                    classesSchedule[i, j] = @class;
                }
            }

            return classesSchedule;
        }

        public Task ScheduleUpdate()
        {
            throw new NotImplementedException();
        }

        public ClassModel GetCurrentClass(int Id)
        {
            return databaseContext.Classes.FirstOrDefault(x => x.Id == Id);
        }
    }
}
