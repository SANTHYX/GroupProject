using Core.Domain;

namespace Core.Commons.Factories
{
    public interface IUserFactory : IFactory
    {
        User CreateInstance();
    }
}
