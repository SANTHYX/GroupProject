using Application.Identity.Commands.RecoveryAccess;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    class RecoveryAccessValidator : AbstractValidator<RecoveryAccess>, Core.Types.IValidator
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
