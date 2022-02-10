using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Movies.Queries.BrowseMovieLibrary
{
    public class BrowseNotIncludedMoviesHandler : IQueryHandler<IEnumerable<MoviesDto>, BrowseNotIncludedMovies>
    {
        private readonly IUnitOfWork _unit;

        public BrowseNotIncludedMoviesHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<MoviesDto>> HandleAsync(BrowseNotIncludedMovies query)
        {
            var movies = await _unit.Movie.GetAllAsync(movie => movie.RoomId != query.RoomId);

            return movies?.Select(movie => new MoviesDto
            {
                Title = movie.Title
            });
        }
    }
}
