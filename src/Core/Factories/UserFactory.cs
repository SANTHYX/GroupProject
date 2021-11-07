using Core.Commons.Factories;
using Core.Domain;
using System;

namespace Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateInstance()
        {
            switch (switch_on)
            {
                case():
                    return new();
                default:
                    throw new Exception("Invalid type of role");
            }
        }
    }
}
