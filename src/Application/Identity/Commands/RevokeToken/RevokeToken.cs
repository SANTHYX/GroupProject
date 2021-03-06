using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.RevokeToken
{
    public record RevokeToken : ICommand
    {
        public string Refresh { get; set; }
    }
}
