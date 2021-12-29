using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Persistance;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RecoveryAccess
{
    public class RecoveryAccessHandler : ICommandHandler<RecoveryAccess>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecoveryThreadStorage _threadStorage;

        public RecoveryAccessHandler(IUnitOfWork unitOfWork, IRecoveryThreadStorage threadStorage)
        {
            _unitOfWork = unitOfWork;
            _threadStorage = threadStorage;
        }

        public async Task HandleAsync(RecoveryAccess command)
        {
            var user = await _unitOfWork.User.GetByEmail(command.Email);

            user.IsNotNull();

            _threadStorage.Create(user);

            //TODO: Mail sending with URL to page that perform setting a new password
        }
    }
}
