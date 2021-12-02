using Application.Identity.Commands.SetPasswordAtRecovery;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Validators.Identity
{
    public class SetPasswordAtRecoveryValidation : AbstractValidator<SetPasswordAtRecovery>
    {
        public SetPasswordAtRecoveryValidation()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.RepeatedPassword)
                .NotEmpty()
                .WithMessage("Passwords don't match");
        }
    }
}
