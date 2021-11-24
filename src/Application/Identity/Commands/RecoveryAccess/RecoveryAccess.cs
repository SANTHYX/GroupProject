using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.RecoveryAccess
{
    public record RecoveryAccess : ICommand
    {
        //this will get email with linked user to change password
        public string Email { get; set; }
    }
}
