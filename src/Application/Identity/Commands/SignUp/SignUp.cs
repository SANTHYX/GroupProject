using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.RegisterUser
{
    public record SignUp : ICommand
    {
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
