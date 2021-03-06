using Core.Commons.Factories;
using Core.Domain;
using Core.Enums;
using System;

namespace Core.Factories
{
    public class RoomFactory : IRoomFactory
    {
        public Room CreateInstance(string name, Accessability accessability, User user)
        {
            return accessability switch
            {
                (Accessability.Public) => new(name ,nameof(Accessability.Public), user),
                (Accessability.Private) => new(name, nameof(Accessability.Private), user),
                (Accessability.OnlyFriends) => new(name, nameof(Accessability.OnlyFriends), user),
                _ => throw new Exception("Invalid type of room"),
            };
        }
    }
}
