using Application.Commons.CQRS.Query;
using Application.Users.Queries.DisplayUser.Dto;
using System;

namespace Application.Users.Queries.DisplayUser
{
    public record DisplayUser : IQuery<DisplayUserDto>
    {
        public Guid Id { get; set; }
    }
}
