using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IMovieRepository : IRepository
    {
        Task AddAsync(Movie movie);
    }
}
