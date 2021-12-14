using Core.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Page(ICollection<T> items, int currentPage, int totalPages, int foundResults)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            FoundResults = foundResults;
        }

        public async Task<IPage<T>> GetPagedResultAsync(IQueryable<T> data, int page = 1, int results = 10)
        {
            page = page <= 0 ? 1 : page;
            results = results <= 0 ? 10 : results;

            var foundResults = await CountResultsAsync(data);

            if (foundResults == 0)
            {
                return Empty();
            }

            var items = await GetPage(data, page, results);
            var totalPages = CalculateTotalPages(foundResults, page);

            return new Page<T>(items ,page, totalPages, foundResults);
        }

        private async Task<int> CountResultsAsync(IQueryable<T> data)
            => await data.CountAsync();

        private async Task<Collection<T>> GetPage(IQueryable<T> data, int page, int results)
            => await data
                .Skip((page - 1) * results)
                .Take(results)
                .ToListAsync()
                as Collection<T>;

        private int CalculateTotalPages(int totalResults, int results)
            => (int)(Math.Ceiling((double)totalResults / results));

        private Page<T> Empty()
        {
            return new(new Collection<T>(), 1, 1, 0);
        }
    }
}
