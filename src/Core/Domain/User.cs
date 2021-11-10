using Core.Types;

namespace Core.Domain
{
    public class User : Entity
    {
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public User(string nickName, string login, string email, string password, string salt)
        {
            NickName = nickName;
            Login = login;
            Email = email;
            Password = password;
            Salt = salt;
        }
    }
}
