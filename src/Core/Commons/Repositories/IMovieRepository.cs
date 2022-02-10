using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IMovieRepository : IRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> expression);
        Task AddAsync(Movie movie);
    }
}
