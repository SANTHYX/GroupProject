using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RefreshToken
{
    public class RefreshTokenHandler : ICommandHandler<RefreshToken>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefreshTokenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task HandleAsync(RefreshToken command)
        {
            throw new NotImplementedException();
        }
    }
}
