using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using Core.Types;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public record BrowseOwnedRooms : AuthenticatedQuery<Page<OwnedRoomDto>>
    {
    }
}
