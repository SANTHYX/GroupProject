using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using Core.Types;
using System;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public record BrowseOwnedRooms : AuthenticatedQuery<Page<OwnedRoomDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int TotalViewers { get; set; }
    }
}
