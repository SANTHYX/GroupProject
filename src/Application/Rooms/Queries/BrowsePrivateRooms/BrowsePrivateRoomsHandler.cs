using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using Core.Enums;
using Core.Types;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowsePrivateRooms
{
    public class BrowsePrivateRoomsHandler : IQueryHandler<Page<PrivateRoomDto>, BrowsePrivateRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowsePrivateRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Page<PrivateRoomDto>> HandleAsync(BrowsePrivateRooms query)
        {
            var accessability = nameof(Accessability.OnlyFriends); 
            var privateRooms = await _unitOfWork.Room
                .GetAllAsync(x => x.Accessability == accessability,query);

            return new()
            {
                Items = privateRooms.Items?.Select(x => new PrivateRoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
                CurrentPage = privateRooms.CurrentPage,
                TotalPages = privateRooms.TotalPages,
                FoundResults = privateRooms.FoundResults
            };
        }
    }
}
