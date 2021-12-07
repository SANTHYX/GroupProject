using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IMessageRepository : IRepository
    {
        Task AddAsync(Message message);
    }
}
