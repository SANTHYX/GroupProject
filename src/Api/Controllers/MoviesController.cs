using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Infrastructure.Tools.FileStreamer;
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

        public async Task<IActionResult> StreamMovieAsync([FromRoute] FileStreamerPlay command)
        {
            

            return Ok(ApiResponse.Success());
        }

    }
}
