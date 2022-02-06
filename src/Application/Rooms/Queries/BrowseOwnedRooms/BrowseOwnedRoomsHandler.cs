using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using Core.Types;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public class BrowseOwnedRoomsHandler : IQueryHandler<Page<OwnedRoomDto>, BrowseOwnedRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseOwnedRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Page<OwnedRoomDto>> HandleAsync(BrowseOwnedRooms query)
        {
            var ownedRoomsPage = await _unitOfWork.Room.GetAllAsync(x => x.UserId == query.UserId, query);

            return new()
            {
                Items = ownedRoomsPage.Items?.Select(x => new OwnedRoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.User.NickName,
                    TotalViewers = x.Viewers.Count(),
                    OnlineViewers = x.Viewers.Where(viewer => viewer.isOnline).Count()
                }) 
                as Collection<OwnedRoomDto>,
                CurrentPage = ownedRoomsPage.CurrentPage,
                TotalPages = ownedRoomsPage.TotalPages,
                FoundResults = ownedRoomsPage.FoundResults,
            };
        }
    }
}
