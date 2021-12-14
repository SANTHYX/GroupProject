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
        public ICollection<Viewer> Viewers { get; set; }
        public ICollection<Message> Chat { get; set; }
        public ICollection<Movie> Movies { get; set; }

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
