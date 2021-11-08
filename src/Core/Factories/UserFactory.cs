using Core.Commons.Factories;
using Core.Domain;
using System;

namespace Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateInstance(string nickName, string login, string email, string password)
        {
            switch ("x")
            {
                default:
                    return new(nickName, login, email, password);
            }
        }
    }
}
