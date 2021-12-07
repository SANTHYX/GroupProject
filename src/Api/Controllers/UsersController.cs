using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Users.Commands.AddNickName;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : BaseAppController
    {
        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {

        }

        [HttpPut]
        public async Task<IActionResult> AddNickName([FromBody] AddNickName command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
