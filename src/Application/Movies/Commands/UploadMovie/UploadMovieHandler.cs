using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations;
using Application.Commons.Persistance;
using Application.Commons.Tools;
using Core.Domain;
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
            var room = await _unitOfWork.Room.GetByIdAsync(command.RoomId);
            room.BelongsTo(command.UserId, "You are not authorized to perform this operation");

            var serializedFileName = await _videoWriter.SaveFileAsync(command.File);
            Movie movie = new(command.Title,serializedFileName, room);
            await _unitOfWork.Movie.AddAsync(movie);
            await _unitOfWork.CommitAsync();
        }
    }
}
