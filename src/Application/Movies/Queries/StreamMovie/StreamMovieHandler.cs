using Application.Commons.CQRS.Query;
using Application.Movies.Queries.GetMovie.Dto;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovie
{
    public class StreamMovieHandler : IQueryHandler<MovieDto, StreamMovie>
    {
        public async Task<MovieDto> HandleAsync(StreamMovie query)
        {
            throw new System.NotImplementedException();
        }
    }
}
