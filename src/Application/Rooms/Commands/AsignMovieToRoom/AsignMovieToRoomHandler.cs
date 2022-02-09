using Application.Commons.CQRS.Command;
using Application.Commons.Extensions.Validations.Users;
using Application.Commons.Persistance;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AsignMovieToRoom
{
    public class AsignMovieToRoomHandler : ICommandHandler<AsignMovieToRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsignMovieToRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AsignMovieToRoom command)
        {
            var user = await _unitOfWork.User.GetById(command.UserId);
            user.IsExist("You have not permissions to perform that operation");
            var room = await _unitOfWork.Room.GetByIdAsync(command.RoomId);
            if (room == null)
            {
                throw new Exception("Napisz ze ten wyjatek jak tak je lubisz lol");
            }
            var movie = await _unitOfWork.Movie.GetMovieAsync(command.MovieId);
            if (room == null)
            {
                throw new Exception("Napisz ze ten wyjatek jak tak je lubisz lol");
            }

            if (room.Movies == null)
            {
                room.Movies = new List<Movie>();
            }
            if (movie.Rooms == null)
            {
                movie.Rooms = new List<Room>();
            }
            room.Movies.ToList().Add(movie);
            _unitOfWork.Room.Update(room);
            movie.Rooms.ToList().Add(room);
            _unitOfWork.Movie.Update(movie);

            await _unitOfWork.CommitAsync();
        }

    }
}
