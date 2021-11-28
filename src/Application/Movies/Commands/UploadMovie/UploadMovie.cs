using Application.Commons.CQRS.Command;
using Microsoft.AspNetCore.Http;

namespace Application.Movies.Commands.UploadMovie
{
    public record UploadMovie : ICommand
    {
        public IFormFile File { get; set; }
    }
}
