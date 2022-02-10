using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AddMovieToRoom
{
    public class AddMovieToRoomHandler : ICommandHandler<AddMovieToRoom>
    {
        private readonly IUnitOfWork _unit;

        public AddMovieToRoomHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task HandleAsync(AddMovieToRoom command)
        {
            var room = await _unit.Room.GetByIdAsync(command.RoomId);
            if (room.UserId != command.UserId) 
                throw new UnauthorizedAccessException("You cannot perform that operation");
            if (room.Movies.Any(movie => movie.FileName == command.FileName)) 
                throw new Exception("Movie already exist in room library");
            var movie = await _unit.Movie.GetByFileNameAsync(command.FileName);
            if(movie == null)
                throw new Exception("Given is empty");

            movie.Rooms.Add(room);
            _unit.Movie.Update(movie);
            await _unit.CommitAsync();
        }
    }
}
