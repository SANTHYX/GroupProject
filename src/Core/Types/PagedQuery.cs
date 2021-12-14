namespace Core.Types
{
    public abstract class PagedQuery
    {
        public int Page { get; set; }
        public int Results { get; set; }
    }
}
