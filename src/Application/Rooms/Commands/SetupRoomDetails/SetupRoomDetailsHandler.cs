using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Persistance;
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
            var room = await _unitOfWork.Room.GetByIdAsync(command.RoomId);
            room.IsNotNull("Room not exists")
                .BelongsTo(command.UserId, "You have not permissions to perform that operation");    
        }
    }
}
