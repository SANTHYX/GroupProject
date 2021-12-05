using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateRoom command)
        {
            var user = await _unitOfWork.User.GetById(command.UserId);

            if(user == null)
                throw new UnauthorizedAccessException("You have not permissions to perform that operation");

            Room room = 
        }
    }
}
