using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
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

        public async Task<ICollection<User>> GetAllByIdCollection(ICollection<Guid> idCollection)
            => await _context.Users
            .Where(x => idCollection.Contains(x.Id))
            .ToListAsync();

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task<bool> IsExistWithMail(string email)
            => await _context.Users.AnyAsync(x => x.Email == email);

        public async Task<bool> IsExistWithLogin(string login)
            => await _context.Users.AnyAsync(x => x.Login == login);
    }
}
