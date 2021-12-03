using Core.Commons.Factories;
using Core.Domain;
using System;

namespace Core.Factories
{
    public class RoomFactory : IFactory
    {
        // TODO : We will do that on enum or static strings class
        public Room CreateInstance(bool isPublic)
        {
            switch (isPublic)
            {
                case(true):
                    return new();
                case(false):
                    return new();
                default:
                    throw new Exception("Invalid type of room");
            }
        }
    }
}
