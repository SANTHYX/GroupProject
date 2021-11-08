using System;

namespace Core.Types
{
    public abstract class Entity : IEntity
    {
        //this only must give
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
