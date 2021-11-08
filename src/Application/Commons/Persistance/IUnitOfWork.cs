using Core.Commons.Repositories;
using System.Threading.Tasks;

namespace Application.Commons.Persistance
{
    public interface IUnitOfWork
    {
        public IUserRepository User { get; }
        public Task CommitAsync();
    }
}
