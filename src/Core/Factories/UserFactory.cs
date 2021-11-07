using Core.Commons.Factories;
using Core.Domain;
using System;

namespace Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateInstance()
        {
            switch ("x")
            {
                default:
                    return new();
                    break;
            }
        }
    }
}
