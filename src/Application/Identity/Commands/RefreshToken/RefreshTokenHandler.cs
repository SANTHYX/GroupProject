using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Extensions.Validations.Token;
using Application.Commons.Persistance;
using Application.Commons.Services;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RefreshToken
{
    public class RefreshTokenHandler : ICommandHandler<RefreshToken>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _service;

        public RefreshTokenHandler(IUnitOfWork unitOfWork, IIdentityService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task HandleAsync(RefreshToken command)
        {
            var token = await _unitOfWork.Token.GetByRefreash(command.Refresh);
            var user = await _unitOfWork.User.GetById(token.UserId);

            token.IsNotNull("You dont have permisson to perform this operation")
                .AlreadyRevoked();

            await _service.RevokeToken(token);

            var newToken = await _service.GenerateToken(user);

            command.Token = newToken;
        }
    }
}
