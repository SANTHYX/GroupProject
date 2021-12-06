using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.CloseRoom
{
    public class CloseRoomHandler : ICommandHandler<CloseRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CloseRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CloseRoom command)
        {
            var room = await _unitOfWork.Room.GetById(command.RoomId);

            if (room == null)
                throw new Exception("Room with given id not exist");
            if (room.UserId != command.UserId)
                throw new UnauthorizedAccessException("You are not authorized to perform that operation");        
        }
    }
}
