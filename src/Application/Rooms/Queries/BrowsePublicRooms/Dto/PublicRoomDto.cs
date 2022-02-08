using System;

namespace Application.Rooms.Queries.BrowsePublicRooms.Dto
{
    public record PublicRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
