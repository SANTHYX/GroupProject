using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignInHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(SignIn command)
        {
            throw new System.NotImplementedException();
        }


    }
}
