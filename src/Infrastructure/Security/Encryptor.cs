using Core.Commons.Security;
using Core.Domain;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Security
{
    public class Encryptor : IEncryptor
    {
        private readonly int bytesNumber = 42;

        public (string hash, string salt) HashPassword(string password)
        {
            var salt = GenerateSalt();
            var hash = GenerateHash(password, salt);

            return (hash, salt);
        }

        public bool IsValidCreendentials(string password, User user)
            => user.Password == GenerateHash(password, user.Salt);

        private string GenerateHash(string password, string salt)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password),
                    "Cannot generate hash becouse password is empty");
            }
            if (salt is null)
            {
                throw new ArgumentNullException(nameof(password),
                    "Cannot generate hash becouse salt is empty");
            }

            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.Unicode.GetBytes(password + salt));

            return Convert.ToBase64String(hash);
        }

        private string GenerateSalt()
        {
            var rand = new Random();
            var bytes = new byte[bytesNumber];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
