using Application.Commons.CQRS.Query;
using Application.Commons.Dto;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;

namespace Application.Rooms.Queries.BrowsePrivateRooms
{
    public record BrowsePrivateRooms : AuthenticatedQuery<PageDto<PrivateRoomDto>>
    {

    }
}
