using Application.Commons.CQRS.Query;
using Application.Users.Queries.FindNewRoomMemberByNickName.Dto;
using Core.Types;

namespace Application.Users.Queries.FindNewRoomMemberByNickName
{
    public record FindNewRoomMemberByNickName : AuthenticatedQuery<Page<PotentialMemberDto>>
    {
        public string NickName { get; set;}
    }
}
