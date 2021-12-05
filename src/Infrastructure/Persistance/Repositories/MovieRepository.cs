using Core.Commons.Repositories;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }
    }
}
