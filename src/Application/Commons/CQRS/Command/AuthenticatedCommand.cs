using System;
using System.Text.Json.Serialization;

namespace Application.Commons.CQRS.Command
{
    public abstract record AuthenticatedCommand : ICommand
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
