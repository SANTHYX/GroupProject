using System;

namespace Application.Movies.Queries.BrowseMovieLibrary.Dto
{
    public class MoviesDto
    {
        public string FileName { get; set; }
        public string Title { get; set; }  
        public Uri Uri { get; set; }
    }
}
