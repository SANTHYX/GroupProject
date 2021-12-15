using System.Linq;
using System.Threading.Tasks;

namespace Core.Types
{
    public interface IPaging<T> where T : class
    {
        Task<Page<T>> GetPagedResultAsync(IQueryable<T> data, int page = 1, int results = 10);
    }
}
