using Core.Types;

namespace Core.Domain
{
    public class Message : Entity
    {
        public Room Room { get; set; }
        public string Value { get; set; }
    }
}
