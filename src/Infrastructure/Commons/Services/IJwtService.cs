using Core.Commons.Identity;
using Core.Domain;
using System;

namespace Infrastructure.Commons.Services
{
    public interface IJwtService
    {
        (string tokenPayload, IdentityToken identityToken, DateTime expirationTime) CreateJWT(User user);
    }
}
