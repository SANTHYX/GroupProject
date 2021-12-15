using System.Threading.Tasks;

namespace Application.Commons.CQRS.Query
{
    public interface IQueryHandler<TResult, QSource> where QSource : IQuery<TResult>
    {
        Task<TResult> HandleAsync(QSource query);
    }
}
