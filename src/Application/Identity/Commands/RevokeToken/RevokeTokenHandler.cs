using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Application.Commons.Services;
using System;
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

            if(token == null)
                throw new UnauthorizedAccessException("You dont have permission to perform that operation");
            if(token.IsRevoked) return;

            await _service.RevokeToken(token);
        }
    }
}
