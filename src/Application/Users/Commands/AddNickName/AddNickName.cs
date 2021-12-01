using Application.Commons.CQRS.Command;

namespace Application.Users.Commands.AddNickName
{
    public record AddNickName : AuthenticatedCommand
    {
        public string NickName { get; set; }
    }
}
