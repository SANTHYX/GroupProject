using Application.Commons.CQRS.Command;
using System;

namespace Application.Rooms.Commands.SetupRoomDetails
{
    public record SetupRoomDetails : AuthenticatedCommand
    {
        public Guid RoomId { get; set; }
        public string Name { get;  set; }
        public bool IsChatActive { get; set; }
    }
}
