using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using Core.Types;

namespace Application.Rooms.Queries.BrowsePrivateRooms
{
    public record BrowsePrivateRooms : AuthenticatedQuery<Page<PrivateRoomDto>>
    {

    }
}
