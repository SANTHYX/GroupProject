using Application.Commons.CQRS.Command;
using Core.Domain;

namespace Application.Identity.Commands.ChangeCreedentials
{
    public record ChangeCreedentials : ICommand
    {
        //this will set a new paswword for logged user

        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public User user { get; set; }

        public ChangeCreedentials()
        {
               
        }
    }
}
