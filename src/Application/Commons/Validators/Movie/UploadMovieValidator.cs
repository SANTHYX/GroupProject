using Application.Movies.Commands.UploadMovie;
using FluentValidation;

namespace Application.Commons.Validators.Movie
{
    public class UploadMovieValidator : AbstractValidator<UploadMovie>
    {
        public UploadMovieValidator()
        {
         
        }
    }
}
