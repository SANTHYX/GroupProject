using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Movies.Queries.GetMovie.Dto;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovie
{
    public class StreamMovieHandler : IQueryHandler<MovieDto, StreamMovie>
    {
        private readonly IUnitOfWork _unit;

        public StreamMovieHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }



        public async Task<MovieDto> HandleAsync(StreamMovie query)
        {
            throw new System.NotImplementedException();
        }
    }
}
