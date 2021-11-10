using Core.Domain;

namespace Core.Commons.Security
{
    public interface IEncryptor
    {
        (string hash, string salt) HashPassword(string password);
        bool IsValidCreendentials(string password, User user);
    }
}
