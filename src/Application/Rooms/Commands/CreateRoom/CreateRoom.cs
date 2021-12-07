using Application.Commons.CQRS.Command;
using Core.Enums;

namespace Application.Rooms.Commands.CreateRoom
{
    public record CreateRoom : AuthenticatedCommand
    {
        public string Name { get; set; }
        public Accessability Accessability { get; set; }
    }
}
