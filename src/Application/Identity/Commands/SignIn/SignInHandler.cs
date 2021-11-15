using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUnitOfWork _unit;

        public SignInHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task HandleAsync(SignIn command)
        {
            throw new System.NotImplementedException();
        }
    }
}
