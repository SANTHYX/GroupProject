using Core.Domain;
using FluentValidation;

namespace Core.Commons.Validations
{
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid Email")
                .NotEmpty()
                .WithMessage("Email is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.Salt)
                .NotEmpty()
                .WithMessage("Salt is reqired");
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Login is required");
        }
    }
}
