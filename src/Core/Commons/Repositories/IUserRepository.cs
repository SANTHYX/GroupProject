using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task AddAsync(User user);
    }
}
