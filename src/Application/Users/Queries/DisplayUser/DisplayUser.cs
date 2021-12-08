using Application.Commons.CQRS.Query;
using System;

namespace Application.Users.Queries.DisplayUser
{
    public record DisplayUser : IQuery<DisplayUser>
    {
        public Guid Id { get; set; }
    }
}
