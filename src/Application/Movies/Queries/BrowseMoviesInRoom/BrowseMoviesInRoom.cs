using Application.Commons.CQRS.Query;
using Application.Movies.Queries.BrowseMoviesInRoom.Dto;
using System.Collections.Generic;

namespace Application.Movies.Queries.BrowseMoviesInRoom
{
    public class BrowseMoviesInRoom : IQuery<IEnumerable<MovieDto>>
    {
    }
}
