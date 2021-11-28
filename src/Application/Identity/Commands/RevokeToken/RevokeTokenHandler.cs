using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenHandler : ICommandHandler<RevokeToken>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RevokeTokenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(RevokeToken command)
        {
            throw new NotImplementedException();
        }
    }
}
