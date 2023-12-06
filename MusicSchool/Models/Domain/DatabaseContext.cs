﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicSchool.Models.Domain
{
    public class DatabaseContext: IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }

        public DbSet<UnconfirmedUserModel> UnconfirmedUsers { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<StudentGroupModel> StudentGroups { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<TeacherPositionModel> TeachersPositions { get; set;}
    }
}
