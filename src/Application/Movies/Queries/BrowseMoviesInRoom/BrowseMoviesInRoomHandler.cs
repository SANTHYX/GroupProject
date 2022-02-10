using Application.Movies.Queries.BrowseMoviesInRoom.Dto;
using Application.Commons.CQRS.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Movies.Queries.BrowseMoviesInRoom
{
    public class BrowseMoviesInRoomHandler : IQueryHandler<IEnumerable<MovieDto>, BrowseMoviesInRoom>
    {
        public Task<IEnumerable<MovieDto>> HandleAsync(BrowseMoviesInRoom query)
        {
            throw new System.NotImplementedException();
        }
    }
}
