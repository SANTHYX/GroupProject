using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByLogin(string login);
        Task<User> GetByEmail(string email);
        Task AddAsync(User user);
        void Update(User user);
        Task<bool> IsExist(string email);
    }
}
