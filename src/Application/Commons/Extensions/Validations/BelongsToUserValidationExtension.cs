using Core.Types;
using System;

namespace Application.Commons.Extensions.Validations
{
    public static class BelongsToUserValidationExtension
    {
        public static T BelongsTo<T>(this T entity, Guid ownerId, string exceptionMessage = "Invalid Creedentials") where T : Entity
            => entity.Id == ownerId ? entity : throw new UnauthorizedAccessException(exceptionMessage);
    }
}
