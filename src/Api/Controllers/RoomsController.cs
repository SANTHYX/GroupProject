using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Rooms.Commands.AddUsersToRoom;
using Application.Rooms.Commands.CreateRoom;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomsController : BaseAppController
    {
        public RoomsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {

        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoom command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpPut("add-users")]
        public async Task<IActionResult> AddUsersToRoomAsync([FromBody] AddUsersToRoom command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
