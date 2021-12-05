using Core.Commons.Identity;
using Core.Types;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User : Entity
    {
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public ICollection<IdentityToken> IdentityTokens { get; set; }
        public ICollection<Room> Rooms { get; set; }

        protected User()
        {

        }

        public User(string nickName, string login, string email, string password, string salt)
        {
            NickName = nickName;
            Login = login;
            Email = email.ToLower();
            Password = password;
            Salt = salt;
        }
    }
}
