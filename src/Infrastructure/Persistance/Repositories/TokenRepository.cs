using Core.Commons.Identity;
using Core.Commons.Repositories;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DataContext _context;
        public TokenRepository(DataContext context)
        {
            _context = context;
        }
        public Task AddAsync(IdentityToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityToken> GetByRefreash(string refreash)
        {
            throw new NotImplementedException();
        }

        public void Update(IdentityToken token)
        {
            throw new NotImplementedException();
        }
    }
}
