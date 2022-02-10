using Core.Domain;
using Core.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByLogin(string login);
        Task<User> GetByEmail(string email);
        Task<User> GetAggregateById(Guid id);
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetAllByIdCollection(IEnumerable<Guid> idCollection);
        Task<Page<User>> GetAllAsync(Expression<Func<User, bool>> expression, PagedQuery query);
        Task<bool> IsExistWithMail(string email);
        Task<bool> IsExistWithLogin(string login);
        Task AddAsync(User user);
        void Update(User user);
    }
}
