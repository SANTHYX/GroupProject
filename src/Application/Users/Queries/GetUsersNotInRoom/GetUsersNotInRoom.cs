using Application.Commons.CQRS.Query;
using Application.Users.Queries.GetUsersNotInRoom.Dto;
using System;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUsersNotInRoom
{
    public record GetUsersNotInRoom : IQuery<IEnumerable<UserDto>>
    {
        public Guid RoomId { get; set;}
    }
}
