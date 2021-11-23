using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenHandler : ICommandHandler<RevokeToken>
    {
        public Task HandleAsync(RevokeToken command)
        {
            throw new NotImplementedException();
        }
    }
}
