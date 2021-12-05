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
        public ITokenRepository Token { get; }
        public IRoomRepository Room { get; }
        public IMovieRepository Movie { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            User = new UserRepository(context);
            Token = new TokenRepository(context);
            Room = new RoomRepository(context);
            Movie = new MovieRepository(context);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            
            await _context.SaveChangesAsync(cancellationToken);
            
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}
