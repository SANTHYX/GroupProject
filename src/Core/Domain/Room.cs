using Core.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public string Accessability { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Viewer> Viewers { get; set; }
        public IEnumerable<Message> Chat { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        protected Room()
        {

        }

        public Room(string name, string accessability, User user)
        {
            Name = name;
            Accessability = accessability;
            User = user ?? throw new ArgumentNullException(nameof(user),
                "Cannot bind Room with null User instance");         
        }
    }
}
