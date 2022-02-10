using System;

namespace Application.Users.Queries.GetUsersWithRoom.Dto
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}
