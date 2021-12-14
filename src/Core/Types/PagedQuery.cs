namespace Core.Types
{
    public abstract record PagedQuery
    {
        public int Page { get; set; }
        public int Results { get; set; }
    }
}
