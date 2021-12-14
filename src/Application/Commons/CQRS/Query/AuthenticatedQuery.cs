using Core.Types;
using System;
using System.Text.Json.Serialization;

namespace Application.Commons.CQRS.Query
{
    public record AuthenticatedQuery<TResult> : PagedQuery, IQuery<TResult>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
