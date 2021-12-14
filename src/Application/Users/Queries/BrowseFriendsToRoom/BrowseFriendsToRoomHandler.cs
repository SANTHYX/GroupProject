using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Users.Queries.BrowseFriendsToRoom.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Users.Queries.BrowseFriendsToRoom
{
    public class BrowseFriendsToRoomHandler : IQueryHandler<ICollection<FriendDto>, BrowseFriendsToRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowseFriendsToRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<FriendDto>> HandleAsync(BrowseFriendsToRoom query)
        {
            throw new System.NotImplementedException();
        }
    }
}
