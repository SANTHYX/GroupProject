using System.Threading.Tasks;

namespace Application.Commons.CQRS.Command
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
