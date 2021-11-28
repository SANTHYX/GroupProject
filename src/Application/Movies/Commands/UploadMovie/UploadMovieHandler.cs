using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Movies.Commands.UploadMovie
{
    public class UploadMovieHandler : ICommandHandler<UploadMovie>
    {
        public Task HandleAsync(UploadMovie command)
        {
            throw new NotImplementedException();
        }
    }
}
