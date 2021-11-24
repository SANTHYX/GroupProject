using Application.Commons.Persistance;
using Core.Commons.Repositories;
using Infrastructure.Persistance.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IUserRepository User { get; }


        public UnitOfWork(DataContext context)
        {
            _context = context;
            User = new UserRepository(context);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            
            await _context.SaveChangesAsync(cancellationToken);
            
        }

        public Task CommitAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
