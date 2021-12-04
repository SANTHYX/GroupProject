using Core.Types;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public string Accessability { get; set; }
        public ICollection<Message> Chat { get; set; }

        protected Room()
        {

        }

        public Room(string accessability)
        {
            Accessability = accessability;
        }
    }
}
