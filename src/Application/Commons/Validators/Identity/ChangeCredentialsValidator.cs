using Application.Identity.Commands.ChangeCreedentials;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Validators.Identity
{
    public class ChangeCredentialsValidator : AbstractValidator<ChangeCreedentials>
    {
        public ChangeCredentialsValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Password is required"); 
            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty()
                .WithMessage("Passwords don't match"); 
        }
    }
}
