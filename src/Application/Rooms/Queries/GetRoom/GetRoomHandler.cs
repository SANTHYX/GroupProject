using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.GetRoom.Dto;
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
            throw new System.NotImplementedException();
        }
    }
}
