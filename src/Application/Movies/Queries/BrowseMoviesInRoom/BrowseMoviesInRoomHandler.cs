using Application.Movies.Queries.BrowseMoviesInRoom.Dto;
using Application.Commons.CQRS.Query;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commons.Persistance;
using System.Linq;

namespace Application.Movies.Queries.BrowseMoviesInRoom
{
    public class BrowseMoviesInRoomHandler : IQueryHandler<IEnumerable<MovieDto>, BrowseMoviesInRoom>
    {
        private readonly IUnitOfWork _unit;

        public BrowseMoviesInRoomHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<MovieDto>> HandleAsync(BrowseMoviesInRoom query)
        {
            var movies = await _unit.Movie.GetAllAsync(movie => movie.RoomId == query.RoomId);

            return movies?.Select(movie => new MovieDto
            {
                Title = movie.Title
            });
        }
    }
}
