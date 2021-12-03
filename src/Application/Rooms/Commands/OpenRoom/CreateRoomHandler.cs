using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        public Task HandleAsync(CreateRoom command)
        {
            throw new NotImplementedException();
        }
    }
}
