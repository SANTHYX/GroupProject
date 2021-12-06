using Application.Commons.CQRS.Command;
using System;

namespace Application.Rooms.Commands.AddUsersToRoom.Models
{
    public record UserModel : ICommand
    {
        public Guid Id { get; set; }
    }
}
