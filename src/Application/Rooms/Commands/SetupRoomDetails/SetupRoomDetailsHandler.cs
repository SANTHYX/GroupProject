using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.SetupRoomDetails
{
    public class SetupRoomDetailsHandler : ICommandHandler<SetupRoomDetails>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetupRoomDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(SetupRoomDetails command)
        {
            var room = await _unitOfWork.Room.GetById(command.RoomId);

            if (room == null)
                throw new Exception("Room not exists");
            if (room.UserId != command.UserId)
                throw new UnauthorizedAccessException("You have not permissions to perform that operation");
        }
    }
}
