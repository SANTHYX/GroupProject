using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Movie> GetByFileNameAsync(string fileName)
            => await _context.Movies.FirstOrDefaultAsync(x => x.FileName == fileName);

        public async Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> expression)
            => await _context.Movies
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }

        public void Update(Movie movie)
        {
            _context.Update(movie);
        }
    }
}
