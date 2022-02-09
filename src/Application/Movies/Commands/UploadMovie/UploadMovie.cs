using Application.Commons.CQRS.Command;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Movies.Commands.UploadMovie
{
    public record UploadMovie : AuthenticatedCommand
    {
        public string Title { get; set; }
        public IFormFile File { get; set; }
    }
}
