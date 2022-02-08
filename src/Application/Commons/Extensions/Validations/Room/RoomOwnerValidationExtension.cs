using Core.Domain;
using System;

namespace Application.Commons.Extensions.Validations.NewFolder
{
    public static class RoomOwnerValidationExtension
    {
        public static Room OwnedBy(this Room room, Guid ownerId)
            => room.UserId == ownerId ? room : throw new UnauthorizedAccessException("Invalid Creedentials");
    }
}
