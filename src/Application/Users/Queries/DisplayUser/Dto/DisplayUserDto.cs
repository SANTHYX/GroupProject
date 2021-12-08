using System;

namespace Application.Users.Queries.DisplayUser.Dto
{
    public record DisplayUserDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}
