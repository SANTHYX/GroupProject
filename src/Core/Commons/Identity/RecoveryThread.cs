using Core.Domain;
using System;

namespace Core.Commons.Identity
{
    public class RecoveryThread 
    {
        public Guid Id { get; set; }
        public User User { get; set; }

        protected RecoveryThread()
        {

        }

        public RecoveryThread(User user)
        {
            Id = Guid.NewGuid();
            User = user ?? throw new ArgumentNullException(nameof(user), "Thread require user instance");
        }
    }
}
