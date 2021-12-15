using Core.Commons.Identity;
using Core.Commons.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IdentityToken> GetByRefreash(string refreash)
            => await _context.Tokens.FirstOrDefaultAsync(x => x.Refresh == refreash);

        public async Task AddAsync(IdentityToken token)
        {
            await _context.Tokens.AddAsync(token);
        }

        public void Update(IdentityToken token)
        {
            _context.Tokens.Update(token);
        }
    }
}
