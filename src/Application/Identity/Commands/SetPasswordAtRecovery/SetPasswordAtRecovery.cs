using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public record SetPasswordAtRecovery : ICommand
    {
        //recovering user acount with changing password
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}
