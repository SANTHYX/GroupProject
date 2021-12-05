using Core.Types;
using System;

namespace Core.Domain
{
    public class Movie : Entity
    {
        public string FileName { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        protected Movie()
        {

        }

        public Movie(string fileName, Room room)
        {
            FileName = fileName;
            Room = room ?? throw new ArgumentNullException(nameof(room),
                "Cannot bind Room with null Movie instance");
        }
    }
}
