using System.Collections.Generic;

namespace Core.Types
{
    public record Page<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FoundResults { get; set; }

        public Page()
        {

        }

        public Page(IEnumerable<T> items, int currentPage, int totalPages, int foundResults)
        {
            Items = items;
            CurrentPage = currentPage > totalPages ? totalPages : currentPage;
            TotalPages = totalPages;
            FoundResults = foundResults;
        }
    }
}
