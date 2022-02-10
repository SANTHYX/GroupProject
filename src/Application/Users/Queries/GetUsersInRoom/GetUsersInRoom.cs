using Application.Commons.CQRS.Query;
using Application.Users.Queries.GetUsersWithRoom.Dto;
using System;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUsersInRoom
{
    public record GetUsersInRoom : IQuery<IEnumerable<UserDto>>
    {
        public Guid RoomId { get; set; }
    }
}
