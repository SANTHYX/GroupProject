using Application.Commons.CQRS.Command;
using Application.Commons.Extensions;
using Application.Commons.Extensions.Validations;
using Application.Commons.Persistance;
using Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            var room = await _unitOfWork.Room.GetByIdAsync(command.RoomId);

            room.IsNotNull("Room with given id not exist")
                .BelongsTo(command.UserId, "You are not authorized to perform that operation");

            var userIdCollection = command.SelectedUsers.Select(x => x.Id);
            var viewers = await _unitOfWork.Viewer.GetAllByUserIdCollection(userIdCollection);
            
            await ThrowsWhenViewersAreMembersOfRoom(room, viewers);
           
            var users = await _unitOfWork.User.GetAllByIdCollection(userIdCollection);

            viewers = new Collection<Viewer>();

            users.ForEach(x => 
            { 
                Viewer newViewer = new(x);
                viewers.Add(newViewer);
            });

            await _unitOfWork.Viewer.AddManyAsync(viewers);

            viewers.ForEach(x => 
            {
                room.Viewers.Add(x);
            });

            _unitOfWork.Room.Update(room);
            await _unitOfWork.CommitAsync();
        }

        private async Task ThrowsWhenViewersAreMembersOfRoom(Room room, ICollection<Viewer> viewers)
        {
            if (await _unitOfWork.Room.IsMembersOfRoomAsync(room.Id, viewers))
                throw new Exception("In selected group of users one of them are already room member");
        }
    }
}
