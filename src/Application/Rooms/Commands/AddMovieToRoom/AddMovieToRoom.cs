using Application.Commons.CQRS.Command;
using System;

namespace Application.Rooms.Commands.AddMovieToRoom
{
    public record AddMovieToRoom : AuthenticatedCommand
    {
        public Guid RoomId { get; set;}
        public string FileName {  get; set; } 
    }
}
