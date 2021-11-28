using Application.Commons.CQRS.Query;
using Application.Movies.Queries.GetMovie.Dto;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovie
{
    public class GetMovieHandler : IQueryHandler<MovieDto, GetMovie>
    {
        public async Task<MovieDto> HandleAsync(GetMovie query)
        {
            throw new System.NotImplementedException();
        }
    }
}
