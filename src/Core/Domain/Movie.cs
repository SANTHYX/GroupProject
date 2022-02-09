using Core.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public Guid RoomId { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

        protected Movie()
        {

        }

        public Movie(string title, string fileName)
        {
            Title = title;
            FileName = fileName;
        }
    }
}
