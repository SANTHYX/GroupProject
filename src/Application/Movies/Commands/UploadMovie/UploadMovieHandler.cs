using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Application.Commons.Tools;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Application.Movies.Commands.UploadMovie
{
    public class UploadMovieHandler : ICommandHandler<UploadMovie>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IVideoWriter _videoWriter;

        public UploadMovieHandler(IUnitOfWork unitOfWork, IVideoWriter videoWriter)
        {
            _unitOfWork = unitOfWork;
            _videoWriter = videoWriter;
        }

        public async Task HandleAsync(UploadMovie command)
        {
            var user = _unitOfWork.User.GetById(command.UserId);

            if(user == null)
                throw new UnauthorizedAccessException($"You are not authorized to perform this operation");

            var fileName = await _videoWriter.SaveFileAsync(command.File);

            Movie movie = new(fileName);

        }
    }
}
