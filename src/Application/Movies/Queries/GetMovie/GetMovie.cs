using Application.Commons.CQRS.Query;
using Application.Movies.Queries.GetMovie.Dto;

namespace Application.Movies.Queries.GetMovie
{
    public record GetMovie : IQuery<MovieDto>
    {
    }
}
