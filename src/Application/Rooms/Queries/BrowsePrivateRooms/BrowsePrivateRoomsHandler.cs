using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using System;
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
            throw new NotImplementedException();
        }
    }
}
