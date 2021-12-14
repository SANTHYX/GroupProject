using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowsePublicRooms.Dto;

namespace Application.Rooms.Queries.BrowsePublicRooms
{
    public record BrowsePublicRooms : IQuery<PublicRoomDto>
    {
    }
}
