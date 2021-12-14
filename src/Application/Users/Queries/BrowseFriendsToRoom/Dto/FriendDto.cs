using System;

namespace Application.Users.Queries.BrowseFriendsToRoom.Dto
{
    public record FriendDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}
