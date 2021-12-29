using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Extensions.Validations.Token;
using Application.Commons.Persistance;
using Application.Commons.Services;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenHandler : ICommandHandler<RevokeToken>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _service;

        public RevokeTokenHandler(IUnitOfWork unitOfWork, IIdentityService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task HandleAsync(RevokeToken command)
        {
            var token = await _unitOfWork.Token.GetByRefreash(command.Refresh);

            token.IsNotNull("You dont have permission to perform that operation")
                .AlreadyRevoked();

            await _service.RevokeToken(token);
        }
    }
}
