using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Users.Commands.AddNickName;
using Application.Users.Queries.DisplayUser;
using Application.Users.Queries.DisplayUser.Dto;
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

        [HttpGet]
        public async Task<IActionResult> DisplayUserAsync([FromBody] DisplayUser query)
        {   
            var result = await SendAsync<DisplayUserDto, DisplayUser>(query);

            return Ok(ApiResponse<DisplayUserDto>.Success(result));
        }


        [HttpPut]
        public async Task<IActionResult> AddNickNameAsync([FromBody] AddNickName command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
