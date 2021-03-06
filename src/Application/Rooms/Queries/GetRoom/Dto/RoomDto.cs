using Application.Rooms.Queries.GetRoom.Dto.NestedModels;
using System;
using System.Collections.Generic;

namespace Application.Rooms.Queries.GetRoom.Dto
{
    public record RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<MovieDto> Movies { get; set; }
    }
}
