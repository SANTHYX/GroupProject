using Core.Commons.Factories;
using Core.Commons.Security;
using Core.Domain;

namespace Core.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IEncryptor _encryptor;

        public UserFactory(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public User CreateInstance(string nickName, string login, string email, string password)
        {
            var (hash, salt) = _encryptor.HashPassword(password);

            return "x" switch
            {
                _ => new(nickName, login, email, hash, salt),
            };
        }
    }
}
