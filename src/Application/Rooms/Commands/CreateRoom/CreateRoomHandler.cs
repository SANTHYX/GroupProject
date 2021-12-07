using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Commons.Factories;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomFactory _factory;

        public CreateRoomHandler(IUnitOfWork unitOfWork, IRoomFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public async Task HandleAsync(CreateRoom command)
        {
            var user = await _unitOfWork.User.GetById(command.UserId);

            if(user == null)
                throw new UnauthorizedAccessException("You have not permissions to perform that operation");

            Room room = _factory.CreateInstance(command.Name, command.Accessability, user);

            await _unitOfWork.Room.AddAsync(room);
            await _unitOfWork.CommitAsync();
        }
    }
}
