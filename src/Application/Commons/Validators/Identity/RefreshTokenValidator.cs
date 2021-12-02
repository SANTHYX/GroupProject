using Application.Identity.Commands.RefreshToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
