using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Application.Commons.Services;
using System;
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

            if(token is null)
                throw new UnauthorizedAccessException("You dont have permisson to perform this operation");
            if(token.IsRevoked == true)
                throw new Exception("Token has been revoked earlier");

            var newToken = await _service.GenerateToken(user);

            command.Token = newToken;
        }
    }
}
