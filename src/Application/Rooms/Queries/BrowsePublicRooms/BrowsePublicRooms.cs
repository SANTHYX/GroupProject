using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowsePublicRooms.Dto;
using Core.Types;

namespace Application.Rooms.Queries.BrowsePublicRooms
{
    public record BrowsePublicRooms : PagedQuery, IQuery<Page<PublicRoomDto>>
    {
    }
}
