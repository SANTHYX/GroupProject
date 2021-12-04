using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Commons.Factories;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RegisterUser
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFactory _factory;

        public SignUpHandler(IUnitOfWork unitOfWork, IUserFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public async Task HandleAsync(SignUp command)
        {
            if (await _unitOfWork.User.IsExist(command.Email.ToLower()))
            {
                throw new Exception("User already exist");
            }

            var user = _factory.CreateInstance(
                command.NickName,
                command.Login,
                command.Email,
                command.Password);

            await _unitOfWork.User.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

    }
}
