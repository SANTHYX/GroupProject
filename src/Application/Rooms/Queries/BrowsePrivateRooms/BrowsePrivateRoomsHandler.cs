using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using Core.Enums;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowsePrivateRooms
{
    public class BrowsePrivateRoomsHandler : IQueryHandler<PrivateRoomDto, BrowsePrivateRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowsePrivateRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PrivateRoomDto> HandleAsync(BrowsePrivateRooms query)
        {
            var rooms = await _unitOfWork.Room.GetAllAsync(x => 
                x.Accessability == nameof(Accessability.Private));
        }
    }
}
