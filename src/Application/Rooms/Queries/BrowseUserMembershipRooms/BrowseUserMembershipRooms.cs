using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;
using System.Collections.Generic;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms
{
    public record BrowseUserMembershipRooms : IQuery<ICollection<MembershipRoomDto>>
    {
    }
}
