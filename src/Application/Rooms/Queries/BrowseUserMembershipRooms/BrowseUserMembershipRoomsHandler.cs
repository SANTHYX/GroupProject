using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms
{
    public class BrowseUserMembershipRoomsHandler : IQueryHandler<ICollection<MembershipRoomDto>, BrowseUserMembershipRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseUserMembershipRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ICollection<MembershipRoomDto>> HandleAsync(BrowseUserMembershipRooms query)
        {
            throw new System.NotImplementedException();
        }
    }
}
