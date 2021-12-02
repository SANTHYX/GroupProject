﻿using System;

namespace Core.Types
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
