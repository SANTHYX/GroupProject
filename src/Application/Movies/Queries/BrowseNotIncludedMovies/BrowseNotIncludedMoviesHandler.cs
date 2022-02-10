using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Commons.Providers;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Movies.Queries.BrowseMovieLibrary
{
    public class BrowseNotIncludedMoviesHandler : IQueryHandler<IEnumerable<MoviesDto>, BrowseNotIncludedMovies>
    {
        private readonly IUnitOfWork _unit;
        private readonly IServerDetailsProvider _serverProvider;

        public BrowseNotIncludedMoviesHandler(IUnitOfWork unit, IServerDetailsProvider serverProvider)
        {
            _unit = unit;
            _serverProvider = serverProvider;
        }

        public async Task<IEnumerable<MoviesDto>> HandleAsync(BrowseNotIncludedMovies query)
        {
            var movies = await _unit.Movie
                .GetAllAsync(movie => movie.RoomId != query.RoomId || movie.RoomId == null);

            return movies?.Select(movie => new MoviesDto
            {
                FileName = movie.FileName,
                Title = movie.Title,
                Uri = new Uri($"{ _serverProvider.GetBaseServerUrl() }files/{ movie.FileName }")
            });
        }
    }
}
