using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Users.Queries.GetUsersNotInRoom.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersNotInRoom
{
    public class GetUsersNotInRoomHandler : IQueryHandler<IEnumerable<UserDto>, GetUsersNotInRoom>
    {
        private readonly IUnitOfWork _unit;

        public GetUsersNotInRoomHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsersNotInRoom query)
        {
            var users = await _unit.User.GetAllAsync(x => x.Viewer.Rooms.Any(x => x.Id != query.RoomId) || x.Viewer == null);

            return users?.Select(x => new UserDto
            {
                Id = x.Id,
                NickName = x.NickName
            });
        }
    }
}
