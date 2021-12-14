using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms
{
    public record BrowseUserMembershipRooms : IQuery<MembershipRoomDto>
    {
    }
}
