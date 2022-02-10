using Application.Commons.CQRS.Query;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using System;
using System.Collections.Generic;

namespace Application.Movies.Queries.BrowseMovieLibrary
{
    public class BrowseNotIncludedMovies : IQuery<IEnumerable<MoviesDto>>
    {
        public Guid RoomId { get; set; } 
    }
}
