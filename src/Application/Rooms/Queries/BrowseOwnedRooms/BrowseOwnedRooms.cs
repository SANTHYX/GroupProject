using Application.Commons.CQRS.Query;
using Application.Commons.Dto;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public record BrowseOwnedRooms : AuthenticatedQuery<PageDto<OwnedRoomDto>>
    {
    }
}
