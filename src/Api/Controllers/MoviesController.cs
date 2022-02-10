using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Movies.Commands.UploadMovie;
using Application.Movies.Queries.BrowseMovieLibrary;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using Application.Movies.Queries.BrowseMoviesInRoom;
using Application.Movies.Queries.BrowseMoviesInRoom.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : BaseAppController
    {
        public MoviesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
            : base(commandDispatcher, queryDispatcher)
        {

        }

        [Authorize]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadMovie([FromForm] UploadMovie command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpGet("inRoom/{roomId}")]
        public async Task<IActionResult> BrowseMoviesInRoom([FromRoute] BrowseMoviesInRoom query)
        {
            var result = await SendAsync<IEnumerable<MovieDto>,BrowseMoviesInRoom>(query);

            return Ok(ApiResponse<IEnumerable<MovieDto>>.Success(result));
        }

        [HttpGet("notInRoom/{roomId}")]
        public async Task<IActionResult> BrowseNotInclodedMovies([FromRoute] BrowseNotIncludedMovies query)
        {
            var result = await SendAsync<IEnumerable<MoviesDto>, BrowseNotIncludedMovies>(query);

            return Ok(ApiResponse<IEnumerable<MoviesDto>>.Success(result));
        }
    }
}
