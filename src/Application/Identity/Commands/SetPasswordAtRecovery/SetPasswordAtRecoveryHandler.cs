using Application.Commons.CQRS.Command;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public class SetPasswordAtRecoveryHandler : ICommandHandler<SetPasswordAtRecovery>
    {
        public SetPasswordAtRecoveryHandler()
        {

        }

        public Task HandleAsync(SetPasswordAtRecovery command)
        {
            throw new System.NotImplementedException();
        }
    }
}
