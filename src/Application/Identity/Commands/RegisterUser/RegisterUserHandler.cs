using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Commons.Factories;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RegisterUser
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserFactory _factory;

        public RegisterUserHandler(IUnitOfWork unit, IUserFactory factory)
        {
            _unit = unit;
            _factory = factory;
        }

        public async Task HandleAsync(RegisterUser command)
        {
            var user = _factory.CreateInstance(
                command.NickName, command.Login, command.Email, command.Password);
            await _unit.User.AddAsync(user);
            await _unit.CommitAsync();
        }

    }
}
