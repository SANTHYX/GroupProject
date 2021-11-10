using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.LoginUser
{
    public record LoginUser : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
