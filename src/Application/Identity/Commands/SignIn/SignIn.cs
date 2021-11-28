using Application.Commons.CQRS.Command;
using Application.Identity.Commands.LoginUser.Dto;
using System.Text.Json.Serialization;

namespace Application.Identity.Commands.LoginUser
{
    public record SignIn : ICommand
    {
        [JsonIgnore]
        public TokenModel Token { get; set; }
        public string Login { get;  }
        public string Password { get; }

    }
    
}
