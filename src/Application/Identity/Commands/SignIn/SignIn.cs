using Application.Commons.CQRS.Command;
using Application.Identity.Commands.LoginUser.Dto;
using System.Text.Json.Serialization;

namespace Application.Identity.Commands.LoginUser
{
    public record SignIn : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public TokenModel Token { get; set; }
    }
    
}
