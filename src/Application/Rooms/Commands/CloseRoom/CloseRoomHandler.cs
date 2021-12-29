using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Persistance;
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
            var room = await _unitOfWork.Room.GetByIdAsync(command.RoomId);

            room.IsNotNull("Room with given id not exist")
                .BelongsTo(command.UserId, "You are not authorized to perform that operation");     
        }
    }
}
