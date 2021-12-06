using Application.Commons.CQRS.Command;
using System;

namespace Application.Rooms.Commands.CloseRoom
{
    public record CloseRoom : AuthenticatedCommand
    {
        public Guid RoomId { get; set; }
    }
}
