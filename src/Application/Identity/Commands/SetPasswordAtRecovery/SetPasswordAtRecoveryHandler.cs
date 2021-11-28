using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public class SetPasswordAtRecoveryHandler : ICommandHandler<SetPasswordAtRecovery>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SetPasswordAtRecoveryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task HandleAsync(SetPasswordAtRecovery command)
        {
            throw new System.NotImplementedException();
        }
    }
}
