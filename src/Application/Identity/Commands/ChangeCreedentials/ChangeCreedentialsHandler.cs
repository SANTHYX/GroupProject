using Application.Commons.CQRS.Command;
using System.Threading.Tasks;

namespace Application.Identity.Commands.ChangeCreedentials
{
    public class ChangeCreedentialsHandler : ICommandHandler<ChangeCreedentials>
    {
        public ChangeCreedentialsHandler()
        {

        }

        public Task HandleAsync(ChangeCreedentials command)
        {
            throw new System.NotImplementedException();
        }
    }
}
