using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Movies.Queries.BrowseMovieLibrary.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Movies.Queries.BrowseMovieLibrary
{
    public class BrowseMovieLibraryHandler : IQueryHandler<IEnumerable<MoviesDto>, BrowseMovieLibrary>
    {
        private readonly IUnitOfWork _unit;

        public BrowseMovieLibraryHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<MoviesDto>> HandleAsync(BrowseMovieLibrary query)
        {
            
        }
        
    }
}
