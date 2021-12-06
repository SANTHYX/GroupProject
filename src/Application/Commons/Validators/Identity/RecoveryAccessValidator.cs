using Application.Identity.Commands.RecoveryAccess;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    class RecoveryAccessValidator : AbstractValidator<RecoveryAccess>
    {
        public RecoveryAccessValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid Email");
        }
    }
}
