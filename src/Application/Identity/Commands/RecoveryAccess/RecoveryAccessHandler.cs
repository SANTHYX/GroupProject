using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RecoveryAccess
{
    public class RecoveryAccessHandler : ICommandHandler<RecoveryAccess>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecoveryAccessHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task HandleAsync(RecoveryAccess command)
        {
            throw new NotImplementedException();
        }
    }
}
