using System.Linq;
using System.Threading.Tasks;

namespace Core.Types
{
    public interface IPaging<T> where T : Entity
    {
        Task<Page<T>> GetPagedResultAsync(IQueryable<T> data, int page = 1, int results = 10);
    }
}
