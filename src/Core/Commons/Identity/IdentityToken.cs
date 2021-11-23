using Core.Domain;
using Core.Types;
using System;

namespace Core.Commons.Identity
{
    public class IdentityToken : IEntity
    {
        public string Refresh { get; set; }
        public DateTime ExpirationTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        protected IdentityToken()
        {

        }

        public IdentityToken(DateTime expirationTime, User user)
        {
            Refresh = Guid.NewGuid().ToString("N");
            ExpirationTime = expirationTime;
            User = user;
        }

}
}
