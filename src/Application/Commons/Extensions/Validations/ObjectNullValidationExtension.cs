using Core.Types;
using System;

namespace Application.Commons.Extensions.Validations
{
    public static class ObjectNullValidationExtension
    {
        public static T IsNotNull<T>(this T entity, string exceptionMessage = "Object is empty") where T : IEntity
            => entity ?? throw new Exception(exceptionMessage);
    }
}
