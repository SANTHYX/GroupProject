using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Commons.Factories;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RegisterUser
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserFactory _factory;

        public SignUpHandler(IUnitOfWork unit, IUserFactory factory)
        {
            _unit = unit;
            _factory = factory;
        }

        public async Task HandleAsync(SignUp command)
        {
            var user = _factory.CreateInstance(
                command.NickName,
                command.Login,
                command.Email,
                command.Password);

            await _unit.User.AddAsync(user);
            await _unit.CommitAsync();
        }

    }
}
