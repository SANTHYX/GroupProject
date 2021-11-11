using Core.Domain;
using System;

namespace Infrastructure.Commons.Services
{
    public interface IJwtService
    {
        (string tokenPayload, string refresh, DateTime expirationTime) CreateJWT(User user);
    }
}
