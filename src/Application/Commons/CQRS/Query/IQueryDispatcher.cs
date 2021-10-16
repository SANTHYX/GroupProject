using System.Threading.Tasks;

namespace Application.Commons.CQRS.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : IQuery<TResult>;
    }
}
