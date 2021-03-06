using Application.Identity.Commands.RefreshToken;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    public class RefreshTokenValidator : AbstractValidator<RefreshToken>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.Refresh)
                .NotEmpty();
        }
    }
}
