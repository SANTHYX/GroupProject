using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Movie> GetMovieAsync(Guid movieId)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        }
        public void Update(Movie movie)
        {
            _context.Update(movie);
        }
    }
}
