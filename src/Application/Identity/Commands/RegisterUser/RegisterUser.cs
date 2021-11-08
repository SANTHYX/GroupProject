using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.RegisterUser
{
    public record RegisterUser : ICommand
    {
        public int MyProperty { get; set; }
    }
}
