using Core.Domain;
using Core.Enums;

namespace Core.Commons.Factories
{
    public interface IRoomFactory : IFactory
    {
        Room CreateInstance(string name, Accessability accessability, User user);
    }
}
