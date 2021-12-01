using Core.Commons.Identity;
using Core.Domain;
using Infrastructure.Commons.Services;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security.Services
{
    public class JwtService : IJwtService
    {
        private readonly SecuritySettings _settings;

        public JwtService(IOptions<SecuritySettings> settings)
        {
            _settings = settings.Value;
        }

        public (string tokenPayload, IdentityToken identityToken, DateTime expirationTime) CreateJWT(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationTime = DateTime.UtcNow.AddDays(7);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var jwt = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: expirationTime,
                    signingCredentials: signingCredentials);

            var tokenPayload = new JwtSecurityTokenHandler().WriteToken(jwt);

            var identityToken = new IdentityToken(expirationTime, user);

            return (tokenPayload, identityToken, expirationTime);
            
        } 
    }
}
