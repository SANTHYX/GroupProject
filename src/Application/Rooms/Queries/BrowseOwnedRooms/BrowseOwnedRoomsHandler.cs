using Application.Commons.CQRS.Query;
using Application.Commons.Dto;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowseOwnedRooms.Dto;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowseOwnedRooms
{
    public class BrowseOwnedRoomsHandler : IQueryHandler<PageDto<OwnedRoomDto>, BrowseOwnedRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseOwnedRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PageDto<OwnedRoomDto>> HandleAsync(BrowseOwnedRooms query)
        {
            var ownedRoomsPage = await _unitOfWork.Room.GetAllAsync(x => x.UserId == query.UserId,query);

            return new()
            {
                Items = ownedRoomsPage.Items?.Select(x => new OwnedRoomDto
                {
                    
                }) as Collection<OwnedRoomDto>,
                CurrentPage = ownedRoomsPage.CurrentPage,
                TotalPages = ownedRoomsPage.TotalPages,
                FoundResults = ownedRoomsPage.FoundResults,
            };
        }
    }
}
