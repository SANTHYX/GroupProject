using System;

namespace Application.Users.Queries.FindNewRoomMemberByNickName.Dto
{
    public record PotentialMemberDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
    }
}
