using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Rooms.Commands.AddMovieToRoom;
using Application.Rooms.Commands.AddUsersToRoom;
using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Queries.BrowseOwnedRooms;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using Application.Rooms.Queries.BrowsePrivateRooms;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using Application.Rooms.Queries.BrowsePublicRooms;
using Application.Rooms.Queries.BrowsePublicRooms.Dto;
using Application.Rooms.Queries.BrowseUserMembershipRooms;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;
using Application.Rooms.Queries.GetRoom;
using Application.Rooms.Queries.GetRoom.Dto;
using Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom([FromRoute] Guid id)
        {
            var query = new GetRoom() { Id = id };
            var result = await SendAsync<RoomDto, GetRoom>(query);

            return Ok(ApiResponse<RoomDto>.Success(result));
        }

        [Authorize]
        [HttpGet("owned")]
        public async Task<IActionResult> BrowseOwnedRoomsAsync([FromQuery] BrowseOwnedRooms query)
        {
            var result = await SendAsync<Page<OwnedRoomDto>, BrowseOwnedRooms>(query);

            return Ok(ApiResponse<Page<OwnedRoomDto>>.Success(result));
        }
        
        [Authorize]
        [HttpGet("private")]
        public async Task<IActionResult> BrowsePrivateRoomsAsync([FromQuery] BrowsePrivateRooms query)
        {
            var result = await SendAsync<Page<PrivateRoomDto>, BrowsePrivateRooms>(query);

            return Ok(ApiResponse<Page<PrivateRoomDto>>.Success(result));
        }

        [HttpGet("public")]
        public async Task<IActionResult> BrowsePublicRoomsAsync([FromQuery] BrowsePublicRooms query)
        {
            var result = await SendAsync<Page<PublicRoomDto>, BrowsePublicRooms>(query);

            return Ok(ApiResponse<Page<PublicRoomDto>>.Success(result));
        }

        [Authorize]
        [HttpGet("membership")]
        public async Task<IActionResult> BrowseUserMembershipRoomsAsync([FromQuery] BrowseUserMembershipRooms query)
        {
            var result = await SendAsync<Page<MembershipRoomDto>, BrowseUserMembershipRooms>(query);

            return Ok(ApiResponse<Page<MembershipRoomDto>>.Success(result));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoom command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        public async Task<IActionResult> AddMovieToRoom([FromBody] AddMovieToRoom command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [Authorize]
        [HttpPut("add-users")]
        public async Task<IActionResult> AddUsersToRoomAsync([FromBody] AddUsersToRoom command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
