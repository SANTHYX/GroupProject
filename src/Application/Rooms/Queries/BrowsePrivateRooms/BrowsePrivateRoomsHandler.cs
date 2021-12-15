﻿using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Rooms.Queries.BrowsePrivateRooms.Dto;
using Core.Enums;
using Core.Types;
using System.Collections.ObjectModel;
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
            var privateRooms = await _unitOfWork.Room.GetAllAsync(x => 
                x.Accessability == nameof(Accessability.Private),query);

            return new()
            {
                Items = privateRooms.Items?.Select(x => new PrivateRoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                as Collection<PrivateRoomDto>,
                CurrentPage = privateRooms.CurrentPage,
                TotalPages = privateRooms.TotalPages,
                FoundResults = privateRooms.FoundResults
            };
        }
    }
}
