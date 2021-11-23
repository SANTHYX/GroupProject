using Application.Commons.Services;
using Core.Commons.Identity;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastructure.Security.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<IdentityToken> GenerateToken(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
