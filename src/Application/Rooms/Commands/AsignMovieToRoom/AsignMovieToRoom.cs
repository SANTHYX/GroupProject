using Application.Commons.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AsignMovieToRoom
{
    public record AsignMovieToRoom : AuthenticatedCommand
    {
        public Guid RoomId { get; set; }
        public Guid MovieId { get; set; }
    }
}
