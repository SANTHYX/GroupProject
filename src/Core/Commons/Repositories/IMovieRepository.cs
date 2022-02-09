using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IMovieRepository : IRepository
    {
        Task AddAsync(Movie movie);
        Task<Movie> GetMovieAsync(Guid movieId);
        void Update(Movie movie);
    }
}
