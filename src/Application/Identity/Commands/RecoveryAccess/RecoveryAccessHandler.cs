using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RecoveryAccess
{
    public class RecoveryAccessHandler : ICommandHandler<RecoveryAccess>
    {

        public RecoveryAccessHandler()
        {

        }

        public Task HandleAsync(RecoveryAccess command)
        {
            throw new NotImplementedException();
        }
    }
}
