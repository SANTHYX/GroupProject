using Core.Types;

namespace Core.Domain
{
    public class Room : Entity
    {
        public string Accessability { get; set; }

        protected Room()
        {

        }

        public Room(string accessability)
        {
            Accessability = accessability;
        }
    }
}
