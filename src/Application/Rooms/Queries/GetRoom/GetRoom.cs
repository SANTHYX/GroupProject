using Application.Commons.CQRS.Query;
using Application.Rooms.Queries.GetRoom.Dto;
using System;

namespace Application.Rooms.Queries.GetRoom
{
    public record GetRoom : IQuery<RoomDto>
    {
        public Guid Id { get; set; }
    }
}
