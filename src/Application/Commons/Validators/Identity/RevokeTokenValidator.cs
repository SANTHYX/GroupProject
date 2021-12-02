using Application.Identity.Commands.RevokeToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
