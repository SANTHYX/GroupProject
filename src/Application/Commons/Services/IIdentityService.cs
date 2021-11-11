using Core.Domain;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService
    {
        Task<IdentityToken> GenerateToken(User user);
    }
}
