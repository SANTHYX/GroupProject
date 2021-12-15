using Newtonsoft.Json;
using System;

namespace Application.Commons.CQRS.Command
{
    public abstract record AuthenticatedCommand : ICommand
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
