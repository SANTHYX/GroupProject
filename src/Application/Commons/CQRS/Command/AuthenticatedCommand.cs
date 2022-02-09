using System;

namespace Application.Commons.CQRS.Command
{
    public abstract record AuthenticatedCommand : ICommand
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Guid UserId { get; set; }
    }
}
