using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Identity.Commands.LoginUser;
using FluentValidation;

namespace Application.Commons.Validators.Identity
{
    public class SignInValidator : AbstractValidator<SignIn>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
