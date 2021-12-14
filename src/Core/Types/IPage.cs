using System.Linq;
using System.Threading.Tasks;

namespace Core.Types
{
    public interface IPage<TResult>
    {
        Task<IPage<TResult>> GetPagedResultAsync(IQueryable data, int page = 1, int results = 10);
    }
}
