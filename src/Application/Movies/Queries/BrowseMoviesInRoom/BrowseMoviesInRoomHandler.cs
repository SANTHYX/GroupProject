using Application.Movies.Queries.BrowseMoviesInRoom.Dto;
using Application.Commons.CQRS.Query;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commons.Persistance;
using System.Linq;
using Application.Commons.Providers;
using System;

namespace Application.Movies.Queries.BrowseMoviesInRoom
{
    public class BrowseMoviesInRoomHandler : IQueryHandler<IEnumerable<MovieDto>, BrowseMoviesInRoom>
    {
        private readonly IUnitOfWork _unit;
        private readonly IServerDetailsProvider _serverProvider;

        public BrowseMoviesInRoomHandler(IUnitOfWork unit, IServerDetailsProvider serverProvider)
        {
            _unit = unit;
            _serverProvider = serverProvider;
        }

        public async Task<IEnumerable<MovieDto>> HandleAsync(BrowseMoviesInRoom query)
        {
            var movies = await _unit.Movie.GetAllAsync(movie => movie.RoomId == query.RoomId);

            return movies?.Select(movie => new MovieDto
            {
                FileName = movie.FileName,
                Title = movie.Title,
                Url = new Uri($"{ _serverProvider.GetBaseServerUrl() }files/{ movie.FileName }")
            });
        }
    }
}
