using Core.Commons.Identity;
using System;

namespace Application.Commons.Extensions.Validations.Token
{
    public static class AlreadyRevokedValidationExtension
    {
        public static IdentityToken AlreadyRevoked(this IdentityToken token)
        {
            if (token.IsRevoked)
                throw new Exception("Token has been revoked earlier");

            return token;
        }
    }
}
