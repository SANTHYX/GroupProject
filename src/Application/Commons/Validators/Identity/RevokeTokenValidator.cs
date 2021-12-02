using Application.Identity.Commands.RevokeToken;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    public class RevokeTokenValidator : AbstractValidator<RevokeToken>, Core.Types.IValidator
    {
        public RevokeTokenValidator()
        {
            RuleFor(x => x.Refresh)
                .NotEmpty();
        }
    }
}
