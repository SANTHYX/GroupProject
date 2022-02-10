using System;

namespace Application.Users.Queries.GetUsersNotInRoom.Dto
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}
