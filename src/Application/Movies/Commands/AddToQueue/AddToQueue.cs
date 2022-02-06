using Application.Commons.CQRS.Command;

namespace Application.Movies.Commands.AddToQueue
{
    public record AddToQueue : AuthenticatedCommand
    {
        public string MovieTitle { get; set; }
    }
}
