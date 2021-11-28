using Application.Commons.CQRS.Command;

namespace Application.Identity.Commands.ChangeCreedentials
{
    public record ChangeCreedentials : ICommand
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }   
    }
}
