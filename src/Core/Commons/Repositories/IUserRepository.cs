﻿using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetById(Guid id);
        Task AddAsync(User user);
        void Update(User user);
    }
}
