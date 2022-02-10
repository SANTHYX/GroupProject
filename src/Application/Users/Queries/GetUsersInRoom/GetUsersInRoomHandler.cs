using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Users.Queries.GetUsersWithRoom.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersInRoom
{
    public class GetUsersInRoomHandler : IQueryHandler<IEnumerable<UserDto>, GetUsersInRoom>
    {
        private readonly IUnitOfWork _unit;

        public GetUsersInRoomHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsersInRoom query)
        {
            var users = await _unit.User
                .GetAllAsync(x => x.Viewer.Rooms.Any(x => x.Id == query.RoomId));

            return users?.Select(x => new UserDto
            {
                Id = x.Id,
                NickName = x.NickName
            });
        }
    }
}
