using Infrastructure.Externals.Imdb.Requests;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Externals
{
    public interface IImdbClient
    {
        Task<TResult> FetchAsync<TResult, RQuery>(RQuery query) where RQuery : IExternalQuery, new();
    }
}
