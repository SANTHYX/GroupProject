using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AddUsersToRoom
{
    public class AddUsersToRoomHandler : ICommandHandler<AddUsersToRoom>
    {
        public Task HandleAsync(AddUsersToRoom command)
        {
            throw new NotImplementedException();
        }
    }
}
