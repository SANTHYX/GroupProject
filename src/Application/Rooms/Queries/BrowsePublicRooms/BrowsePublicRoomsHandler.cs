using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePublicRooms.Dto;
using Core.Enums;
using Core.Types;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.BrowsePublicRooms
{
    public class BrowsePublicRoomsHandler : IQueryHandler<Page<PublicRoomDto>, BrowsePublicRooms>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowsePublicRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Page<PublicRoomDto>> HandleAsync(BrowsePublicRooms query)
        {
            var publicRooms = await _unitOfWork.Room.GetAllAsync(
                x => x.Accessability == nameof(Accessability.Public), query);

            return new()
            {
                Items = publicRooms.Items?.Select(x => new PublicRoomDto
                {

                })
                as Collection<PublicRoomDto>,
                CurrentPage = publicRooms.CurrentPage,
                TotalPages = publicRooms.TotalPages,
                FoundResults = publicRooms.FoundResults
            };
        }
    }
}
