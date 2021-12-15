using Core.Types;
using Newtonsoft.Json;
using System;

namespace Application.Commons.CQRS.Query
{
    public record AuthenticatedQuery<TResult> : PagedQuery, IQuery<TResult>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
