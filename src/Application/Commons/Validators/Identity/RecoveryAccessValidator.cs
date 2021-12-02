using Application.Identity.Commands.RecoveryAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
