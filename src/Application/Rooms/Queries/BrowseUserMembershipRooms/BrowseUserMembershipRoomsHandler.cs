using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseUserMembershipRooms.Dto;
using Core.Types;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseUserMembershipRooms
{
    public class BrowseUserMembershipRoomsHandler : IQueryHandler<Page<MembershipRoomDto>, BrowseUserMembershipRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseUserMembershipRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Page<MembershipRoomDto>> HandleAsync(BrowseUserMembershipRooms query)
        {
            var roomsWithMembership = await _unitOfWork.Room.GetAllAsync(
                x => x.Viewers.Any(x => x.UserId == query.UserId),
                query);

            return new()
            {
                Items = roomsWithMembership.Items?.Select(x => new MembershipRoomDto
                {

                })
                as Collection<MembershipRoomDto>,
                CurrentPage = roomsWithMembership.CurrentPage,
                TotalPages = roomsWithMembership.TotalPages,
                FoundResults = roomsWithMembership.FoundResults
            };
        }
    }
}
