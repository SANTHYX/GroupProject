using Core.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Pagination
{
    public class Page<T> : IPage<T> where T : Entity
    {
        public ICollection<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FoundResults { get; set; }

        public Page()
        {

        }

        public Task<IPage<T>> GetPagedResultAsync(IQueryable<T> data, int page = 1, int results = 10)
        {
            page = page <= 0 ? 1 : page;
            results = results <= 0 ? 10 : results;

            
        }

        private Page<T> Empty()
        {
            return new();
        }
    }
}
