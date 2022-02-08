using System;

namespace Application.Rooms.Queries.BrowsePrivateRooms.Dto
{
    public record PrivateRoomDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
