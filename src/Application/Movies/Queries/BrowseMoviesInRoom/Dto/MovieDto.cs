using System;

namespace Application.Movies.Queries.BrowseMoviesInRoom.Dto
{
    public class MovieDto
    {
        public string FileName { get; set; }
        public string Title { get; set;}
        public Uri Url { get; set; }
    }
}
