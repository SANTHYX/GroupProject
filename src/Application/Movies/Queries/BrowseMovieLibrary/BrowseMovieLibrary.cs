using Application.Commons.CQRS.Query;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using System.Collections.Generic;

namespace Application.Movies.Queries.BrowseMovieLibrary
{
    public class BrowseMovieLibrary : IQuery<ICollection<MoviesDto>>
    {
    }
}
