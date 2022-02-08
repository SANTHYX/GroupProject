using System;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms.Dto
{
    public record MembershipRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int TotalViewers { get; set; }
        public int OnlineViewers { get; set; }
    }
}
