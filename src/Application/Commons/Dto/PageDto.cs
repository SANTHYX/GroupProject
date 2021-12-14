using System.Collections.Generic;

namespace Application.Commons.Dto
{
    public record PageDto<T>
    {
        public ICollection<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FoundResults { get; set; }
    }
}
