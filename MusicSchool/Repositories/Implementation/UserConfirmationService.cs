﻿using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class UserConfirmationService : IUserConfirmationService
    {
        private readonly DatabaseContext databaseContext;

        public UserConfirmationService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<StatusModel> ConfirmAsStudent()
        {
            throw new NotImplementedException();
        }

        public Task<StatusModel> ConfirmAsTeacher()
        {
            throw new NotImplementedException();
        }

        public Task<StatusModel> LeaveUnconfirmed()
        {
            throw new NotImplementedException();
        }

        public  List<UnconfirmedUserModel> GetAllUnconfirmedUsers()
        {
            var users = databaseContext.UnconfirmedUsers.ToList();

            return users;
        }
    }
}