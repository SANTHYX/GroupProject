using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseRooms.Dto;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseRooms
{
    public class BrowseRoomsHandler : IQueryHandler<BrowseRoomsDto, BrowseRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<BrowseRoomsDto> HandleAsync(BrowseRooms query)
        {
            throw new NotImplementedException();
        }
    }
}
