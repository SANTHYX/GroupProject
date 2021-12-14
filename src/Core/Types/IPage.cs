﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Types
{
    public interface IPage<T>
    {
        public ICollection<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FoundResults { get; set; }

        Task<IPage<T>> GetPagedResultAsync(IQueryable<T> data, int page = 1, int results = 10);
    }
}
