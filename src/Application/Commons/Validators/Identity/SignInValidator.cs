using Application.Identity.Commands.LoginUser;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    public class SignInValidator : AbstractValidator<SignIn>, Core.Types.IValidator
    {
        public SignInValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Login is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
