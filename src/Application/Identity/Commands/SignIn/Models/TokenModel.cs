using System;

namespace Application.Identity.Commands.LoginUser.Dto
{
    public record TokenModel
    {
        public string Payload { get; set; }
        public string Refresh { get; set; }
        public DateTime ExpirationTime {  get; set; }
    }
}
