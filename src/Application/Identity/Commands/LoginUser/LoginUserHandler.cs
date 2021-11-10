using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUnitOfWork _unit;

        public LoginUserHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task HandleAsync(LoginUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}
