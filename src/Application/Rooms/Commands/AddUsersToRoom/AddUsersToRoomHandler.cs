using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /*
         * TODO:
         * 1) Validate room
         * 2) Check if 
         */
        public async Task HandleAsync(AddUsersToRoom command)
        {
            var room = await _unitOfWork.Room.GetById(command.RoomId);

            if (room == null)
                throw new Exception("Room with given id not exist");
            if (room.UserId != command.UserId)
                throw new UnauthorizedAccessException("You are not authorized to perform that operation");

            ICollection<User> selectedUsers = command.SelectedUsers as ICollection<User>;
            ICollection<Viewer> viewers = new Collection<Viewer>();

            foreach (var user in selectedUsers)
            {
                viewers.Add(new(user));
            }

            Console.WriteLine($"Done");
        }
    }
}
