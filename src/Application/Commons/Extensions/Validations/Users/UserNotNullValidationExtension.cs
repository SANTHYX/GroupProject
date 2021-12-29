using Core.Domain;
using System;

namespace Application.Commons.Extensions.Validations.Users
{
    public static class UserNotNullValidationExtension
    {
        public static User IsExist(this User user, string exceptionMessage = "Invalid creedentials")
            => user ?? throw new UnauthorizedAccessException(exceptionMessage);
    }
}
