using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Commons.Security;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public class SetPasswordAtRecoveryHandler : ICommandHandler<SetPasswordAtRecovery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecoveryThreadStorage _threadStorage;
        private readonly IEncryptor _encryptor;

        public SetPasswordAtRecoveryHandler(IUnitOfWork unitOfWork, IRecoveryThreadStorage threadStorage, IEncryptor encryptor)
        {
            _unitOfWork = unitOfWork;
            _threadStorage = threadStorage;
            _encryptor = encryptor;
        }

        public async Task HandleAsync(SetPasswordAtRecovery command)
        {
            var thread = _threadStorage.GetById(command.ThreadId);
            ThrowWhenPasswordsAreDiffrent(command.Password, command.RepeatedPassword);        
            var (hash, salt) = _encryptor.HashPassword(command.Password);
            thread.User.Password = hash; 
            thread.User.Salt = salt;
            _unitOfWork.User.Update(thread.User);
            await _unitOfWork.CommitAsync();
            _threadStorage.Remove(thread);
        }

        private void ThrowWhenPasswordsAreDiffrent(string password, string repeatedPassword)
        {
            if (password != repeatedPassword)
                throw new Exception("Password and RepeatedPassword are not equal");
        }
    }
}
