using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
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
