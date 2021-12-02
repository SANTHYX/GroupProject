using Application.Commons.Persistance;
using Core.Commons.Identity;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistance
{
    public class RecoveryThreadsStorage : IRecoveryThreadStorage
    {
        public ICollection<RecoveryThread> _recoveryThreads { get; } 

        public RecoveryThreadsStorage(ICollection<RecoveryThread> recoveryThreads)
        {
            _recoveryThreads = recoveryThreads;
        }

        public RecoveryThread GetById(Guid id)
            => _recoveryThreads.FirstOrDefault(x => x.Id == id);

        public void Create(User user)
        {
            _recoveryThreads.Add(new(user));
        }

        public void Remove(RecoveryThread thread)
        {
            _recoveryThreads.Remove(thread);
        }
    }
}
