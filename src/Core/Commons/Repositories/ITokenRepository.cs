using Core.Commons.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITokenRepository : IRepository
    {
        Task<IdentityToken> GetByRefreash(string refreash);
        Task AddAsync(IdentityToken token);
        void Update(IdentityToken token);
    }
}
