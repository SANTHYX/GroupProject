using Application.Commons.Persistance;
using Application.Commons.Services;
using Application.Identity.Commands.LoginUser.Dto;
using Core.Commons.Identity;
using Core.Domain;
using Infrastructure.Commons.Services;
using System.Threading.Tasks;

namespace Infrastructure.Security.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _service;

        public IdentityService(IUnitOfWork unitOfWork, IJwtService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<TokenModel> GenerateToken(User user)
        {
            var (tokenPayload, identityToken, expirationTime) = _service.CreateJWT(user);

            await _unitOfWork.Token.AddAsync(identityToken);
            await _unitOfWork.CommitAsync();

            return new TokenModel
            {
                Payload = tokenPayload,
                Refresh = identityToken.Refresh,
                ExpirationTime = expirationTime
            };
        }

        public async Task RevokeToken(IdentityToken token)
        {
            token.IsRevoked = true;

            _unitOfWork.Token.Update(token);
            await _unitOfWork.CommitAsync();
        }
    }
}
