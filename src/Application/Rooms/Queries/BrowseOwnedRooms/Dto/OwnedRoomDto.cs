using System;

namespace Application.Rooms.Queries.BrowseOwnedRooms.Dto
{
    public record OwnedRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
