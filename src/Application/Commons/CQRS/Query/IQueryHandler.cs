using System.Threading.Tasks;

namespace Application.Commons.CQRS.Query
{
    public interface IQueryHandler<TResult, QSource>
    {
        Task<TResult> HandleAsync(QSource query);
    }
}
