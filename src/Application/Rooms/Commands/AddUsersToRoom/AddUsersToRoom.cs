using Application.Commons.CQRS.Command;
using Application.Rooms.Commands.AddUsersToRoom.Models;
using System;
using System.Collections.Generic;

namespace Application.Rooms.Commands.AddUsersToRoom
{
    public record AddUsersToRoom : AuthenticatedCommand
    {
        public Guid RoomId { get; set; }
        public ICollection<UserModel> SelectedUsers { get; set; }
    }
}
