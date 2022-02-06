using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System.Threading.Tasks;

namespace Application.Movies.Commands.AddToQueue
{
    public class AddToQueueHandler : ICommandHandler<AddToQueue>
    {
        private readonly IUnitOfWork _unit;

        public AddToQueueHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task HandleAsync(AddToQueue command)
        {
            
        }
    }
}
