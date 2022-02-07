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
            await ThrowsWhenEmailIsTaken(command.Email);
            await ThrowsWhenLoginIsTaken(command.Login);    
            var user = _factory.CreateInstance(
                command.NickName,
                command.Login,
                command.Email,
                command.Password);

            await _unitOfWork.User.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

        private async Task ThrowsWhenEmailIsTaken(string email)
        {
            if (await _unitOfWork.User.IsExistWithMail(email.ToLower()))
                throw new Exception("User already exist");
        }

        private async Task ThrowsWhenLoginIsTaken(string login)
        {
            if (await _unitOfWork.User.IsExistWithLogin(login))
                throw new Exception("User already exist");
        }
    }
}
