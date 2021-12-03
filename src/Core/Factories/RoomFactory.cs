using Core.Commons.Factories;
using Core.Domain;
using Core.Enums;
using System;

namespace Core.Factories
{
    public class RoomFactory : IRoomFactory
    {
        public Room CreateInstance(Accessability accessability)
        {
            return accessability switch
            {
                (Accessability.Public) => new(nameof(Accessability.Public)),
                (Accessability.Private) => new(nameof(Accessability.Private)),
                (Accessability.OnlyFriends) => new(nameof(Accessability.OnlyFriends)),
                _ => throw new Exception("Invalid type of room"),
            };
        }
    }
}
