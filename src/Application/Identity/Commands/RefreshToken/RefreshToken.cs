using Application.Commons.CQRS.Command;
using Application.Identity.Commands.LoginUser.Dto;
using System.Text.Json.Serialization;

namespace Application.Identity.Commands.RefreshToken
{
    public record RefreshToken : ICommand
    {
        [JsonIgnore]
        public TokenModel Token { get; set; }
        public string Refresh { get; set; }
    }
}
