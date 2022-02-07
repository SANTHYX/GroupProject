using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations.Users;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddNickName
{
    public class AddNickNameHandler : ICommandHandler<AddNickName>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddNickNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddNickName command)
        {
            var user = await _unitOfWork.User.GetById(command.UserId);
            user.IsExist("You have not permissions to perform that operation");
            user.NickName = command.NickName;
            _unitOfWork.User.Update(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
