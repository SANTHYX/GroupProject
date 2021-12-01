using Application.Identity.Commands.LoginUser.Dto;
using Core.Commons.Identity;
using Core.Domain;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService
    {
        Task<TokenModel> GenerateToken(User user);
        Task RevokeToken(IdentityToken token);
    }
}
