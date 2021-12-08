using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Viewers.Command.CreateViewers
{
    public class CreateViewersHandler : ICommandHandler<CreateViewers>
    {
        public Task HandleAsync(CreateViewers command)
        {
            throw new NotImplementedException();
        }
    }
}
