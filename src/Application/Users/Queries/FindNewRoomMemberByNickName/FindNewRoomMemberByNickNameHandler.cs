using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Users.Queries.FindNewRoomMemberByNickName.Dto;
using Core.Types;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.FindNewRoomMemberByNickName
{
    public class FindNewRoomMemberByNickNameHandler : IQueryHandler<Page<PotentialMemberDto>, FindNewRoomMemberByNickName>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindNewRoomMemberByNickNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Page<PotentialMemberDto>> HandleAsync(FindNewRoomMemberByNickName query)
        {
            var members = await _unitOfWork.User.GetAllAsync(
                x => x.NickName.ToLower().Contains(query.NickName.ToLower()), query);

            return new()
            {
                Items = members.Items?.Select(x => new PotentialMemberDto
                {
                    Id = x.Id,
                    NickName = x.NickName,
                })
                as Collection<PotentialMemberDto>,
                CurrentPage = members.CurrentPage,
                TotalPages = members.TotalPages,
                FoundResults = members.FoundResults,
            };
        }
    }
}
