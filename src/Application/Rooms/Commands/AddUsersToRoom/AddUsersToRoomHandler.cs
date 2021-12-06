﻿using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AddUsersToRoom
{
    public class AddUsersToRoomHandler : ICommandHandler<AddUsersToRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUsersToRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddUsersToRoom command)
        {
            var room = await _unitOfWork.Room.GetById(command.RoomId);

            if (room == null)
                throw new Exception("Room with given id not exist");
            if (room.UserId != command.UserId)
                throw new UnauthorizedAccessException("You are not authorized to perform that operation");

            var viewers = command.SelectedUsers as ICollection<Viewer>;
        }
        
    }
}
