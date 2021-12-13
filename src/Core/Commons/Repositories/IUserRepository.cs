using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByLogin(string login);
        Task<User> GetByEmail(string email);
        Task<User> GetAggregateById(Guid id);
        Task<ICollection<User>> GetAllByIdCollection(IEnumerable<Guid> idCollection);
        Task AddAsync(User user);
        void Update(User user);
        Task<bool> IsExistWithMail(string email);
        Task<bool> IsExistWithLogin(string login);
    }
}
