using Application.Identity.Commands.RevokeToken;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    public class RevokeTokenValidator : AbstractValidator<RevokeToken>
    {
        public RevokeTokenValidator()
        {
            RuleFor(x => x.Refresh)
                .NotEmpty();
        }
    }
}
