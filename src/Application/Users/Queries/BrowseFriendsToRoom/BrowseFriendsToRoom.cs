using Application.Commons.CQRS.Query;
using Application.Users.Queries.BrowseFriendsToRoom.Dto;
using System;
using System.Collections.Generic;

namespace Application.Users.Queries.BrowseFriendsToRoom
{
    public record BrowseFriendsToRoom : IQuery<ICollection<FriendDto>>
    {
        public Guid RoomId { get; set; }
    }
}
