using Application.Commons.CQRS.Query;
using Application.Users.Queries.BrowseFriendsToRoom.Dto;
using System;

namespace Application.Users.Queries.BrowseFriendsToRoom
{
    public record BrowseFriendsToRoom : IQuery<FriendDto>
    {
        public Guid RoomId { get; set; }
    }
}
