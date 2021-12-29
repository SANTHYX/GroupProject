using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations.Users;
using Application.Commons.Persistance;
using Core.Commons.Security;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.ChangeCreedentials
{
    public class ChangeCreedentialsHandler : ICommandHandler<ChangeCreedentials>
    {
        private readonly IEncryptor _encryptor;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeCreedentialsHandler(IUnitOfWork unitOfWork, IEncryptor encryptor)
        {
            _unitOfWork = unitOfWork;
            _encryptor = encryptor;
        }

        public async Task HandleAsync(ChangeCreedentials command)
        {
            var user = await _unitOfWork.User.GetById(command.UserId);

            user.IsExist();
            if (command.NewPassword == null) 
                throw new ArgumentNullException(nameof(command.NewPassword), "Password is Required");
            if (command.ConfirmNewPassword == null)
                throw new ArgumentNullException(nameof(command.ConfirmNewPassword), "ConfirmNewPassword is Required");
            if (command.NewPassword != command.ConfirmNewPassword) 
                throw new Exception("Passwords are incorrect");

            var (hash, salt) = _encryptor.HashPassword(command.NewPassword);

            user.Password = hash;
            user.Salt = salt;

            _unitOfWork.User.Update(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
