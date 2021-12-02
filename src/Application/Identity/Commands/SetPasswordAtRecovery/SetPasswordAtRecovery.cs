using Application.Commons.CQRS.Command;
using System;

namespace Application.Identity.Commands.SetPasswordAtRecovery
{
    public record SetPasswordAtRecovery : ICommand
    {
        public Guid ThreadId { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}
