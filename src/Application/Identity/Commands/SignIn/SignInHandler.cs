using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Application.Commons.Services;
using Core.Commons.Security;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptor _encryptor;
        private readonly IIdentityService _service;

        public SignInHandler(IUnitOfWork unitOfWork, IEncryptor encryptor, IIdentityService service)
        {
            _unitOfWork = unitOfWork;
            _encryptor = encryptor;
            _service = service;
        }

        public async Task HandleAsync(SignIn command)
        {
            var user = await _unitOfWork.User.GetByLogin(command.Login);

            if (user is null)
                throw new UnauthorizedAccessException("invalid creednetials");
            if (!_encryptor.IsValidCreendentials(command.Password, user))
                throw new UnauthorizedAccessException("invalid creednetials");

            var token = await _service.GenerateToken(user);

            command.Token = token;
        }
    }
}
