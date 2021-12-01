namespace Infrastructure.Commons.Pagination
{
    public class PagedResponse<T>
    {
        public PagedResponse<T> Empty()
        {
            return new();
        }
    }
}
