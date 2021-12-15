using Application.Commons.CQRS.Query;
using Application.Commons.Dto;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowsePrivateRooms
{
    public class BrowsePrivateRoomsHandler : IQueryHandler<PageDto<PrivateRoomDto>, BrowsePrivateRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowsePrivateRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PageDto<PrivateRoomDto>> HandleAsync(BrowsePrivateRooms query)
        {
            throw new NotImplementedException();
        }
    }
}
