using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public class BrowseOwnedRoomsHandler : IQueryHandler<ICollection<OwnedRoomDto>, BrowseOwnedRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseOwnedRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ICollection<OwnedRoomDto>> HandleAsync(BrowseOwnedRooms query)
        {
            throw new NotImplementedException();
        }
    }
}
