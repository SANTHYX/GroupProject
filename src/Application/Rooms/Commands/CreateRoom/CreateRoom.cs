using Application.Commons.CQRS.Command;

namespace Application.Rooms.Commands.CreateRoom
{
    public record CreateRoom : AuthenticatedCommand
    {
        public string Name { get; set; }
    }
}
