using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Movies.Commands.UploadMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
