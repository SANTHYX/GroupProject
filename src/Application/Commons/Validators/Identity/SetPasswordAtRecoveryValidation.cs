using Application.Identity.Commands.SetPasswordAtRecovery;
using FluentValidation;

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
