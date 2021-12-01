using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public record SetPasswordAtRecovery : ICommand
    {
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}
