using Core.Commons.Identity;
using Core.Domain;
using Core.Types;
using System;

namespace Application.Commons.Persistance
{
    public interface IRecoveryThreadStorage : IInMemoryDatabases
    {
        RecoveryThread GetById(Guid id);
        void Create(User user);
        void Remove(RecoveryThread thread);
    }
}
