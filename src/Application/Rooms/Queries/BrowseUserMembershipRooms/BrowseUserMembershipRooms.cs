using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;
using Core.Types;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms
{
    public record BrowseUserMembershipRooms : AuthenticatedQuery<Page<MembershipRoomDto>>
    {
    }
}
