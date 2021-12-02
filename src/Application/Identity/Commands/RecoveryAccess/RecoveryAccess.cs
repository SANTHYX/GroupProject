using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.RecoveryAccess
{
    public record RecoveryAccess : ICommand
    {
        public string Email { get; set; }
    }
}
