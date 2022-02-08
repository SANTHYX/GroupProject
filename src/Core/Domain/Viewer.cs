using Core.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Viewer : Entity
    {
        public Guid UserId { get ; set; }
        public User User { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public bool isOnline { get; set; }

        protected Viewer()
        {

        }

        public Viewer(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user),
                "Cannot bind Room with null User instance");
        }
    }
}
