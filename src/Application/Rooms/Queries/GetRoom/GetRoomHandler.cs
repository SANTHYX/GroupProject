using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.GetRoom.Dto;
using Application.Rooms.Queries.GetRoom.Dto.NestedModels;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.GetRoom
{
    public class GetRoomHandler : IQueryHandler<RoomDto, GetRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomDto> HandleAsync(GetRoom query)
        {
            var room = await _unitOfWork.Room.GetAggregateByIdAsync(query.Id);

            return room is null ? null : new()
            {
                Id = room.Id,
                Name = room.Name,
                Comments = room.Chat?.Select(comment => new CommentDto
                {
                    Message = comment.Value,
                }),
                Movies = room.Movies?.Select(movie => new MovieDto
                {
                    Title = movie.Title
                })
            };
        }
    }
}
