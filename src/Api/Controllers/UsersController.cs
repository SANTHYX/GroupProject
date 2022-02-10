using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Users.Commands.AddNickName;
using Application.Users.Queries.DisplayUser;
using Application.Users.Queries.DisplayUser.Dto;
using Application.Users.Queries.FindNewRoomMemberByNickName;
using Application.Users.Queries.FindNewRoomMemberByNickName.Dto;
using Application.Users.Queries.GetUsersInRoom;
using Application.Users.Queries.GetUsersNotInRoom;
using Application.Users.Queries.GetUsersNotInRoom.Dto;
using Core.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("notInRoom/{RoomId}")]
        public async Task<IActionResult> GetUsersNotInRoomAsync([FromRoute] GetUsersNotInRoom query)
        {
            var result = await SendAsync<IEnumerable<UserDto>, GetUsersNotInRoom>(query);

            return Ok(ApiResponse<IEnumerable<UserDto>>.Success(result));
        }

        [HttpGet("inRoom/{RoomId}")]
        public async Task<IActionResult> GetUsersInRoomAsync([FromRoute] GetUsersInRoom query)
        {
            var result = await SendAsync<IEnumerable<Application.Users.Queries.GetUsersWithRoom.Dto.UserDto>, GetUsersInRoom>(query);

            return Ok(ApiResponse<IEnumerable<Application.Users.Queries.GetUsersWithRoom.Dto.UserDto>>.Success(result));
        }

        [HttpPut("nickName")]
        public async Task<IActionResult> AddNickNameAsync([FromBody] AddNickName command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
