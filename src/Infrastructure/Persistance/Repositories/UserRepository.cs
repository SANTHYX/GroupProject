using Core.Commons.Repositories;
using Core.Domain;
using Core.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IPaging<User> _paging;

        public UserRepository(DataContext context, IPaging<User> paging)
        {
            _context = context;
            _paging = paging;
        }

        public async Task<User> GetById(Guid id) 
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByLogin(string login)
            => await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

        public async Task<User> GetByEmail(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetAggregateById(Guid id)
            => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> GetAllByIdCollection(IEnumerable<Guid> idCollection)
            => await _context.Users
            .Where(x => idCollection.Contains(x.Id))
            .ToListAsync();

        public async Task<Page<User>> GetAllAsync(Expression<Func<User, bool>> expression, PagedQuery query)
        {
            var result = _context.Users
                .AsNoTracking()
                .Where(expression);

            return await _paging.GetPagedResultAsync(result, query.Page, query.Results);
        }

        public async Task<bool> IsExistWithMail(string email)
            => await _context.Users.AnyAsync(x => x.Email == email);

        public async Task<bool> IsExistWithLogin(string login)
            => await _context.Users.AnyAsync(x => x.Login == login);

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
