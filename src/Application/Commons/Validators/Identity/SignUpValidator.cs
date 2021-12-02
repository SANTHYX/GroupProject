using Application.Identity.Commands.RegisterUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Validators.Identity
{
    public class SignUpValidator : AbstractValidator<SignUp>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid Email")
                .NotEmpty()
                .WithMessage("Email is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Login is required");
            RuleFor(x => x.NickName)
                .NotEmpty()
                .WithMessage("Nick name is required");
        }
    }
}
