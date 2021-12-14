using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.GetRoom.Dto;

namespace Application.Rooms.Queries.GetRoom
{
    public record GetRoom : IQuery<RoomDto>
    {
    }
}
