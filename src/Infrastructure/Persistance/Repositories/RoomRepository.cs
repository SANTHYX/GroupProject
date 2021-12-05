using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Room> GetById(Guid id)
            => await _context.Rooms
            .AsNoTracking()
            .Include(x => x.Chat)
            .Include(x => x.Movies)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Room> GetByUserId(Guid userId)
            => await _context.Rooms.FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task AddAsync(Room room)
        {
            await _context.AddAsync(room);
        }

        public void Update(Room room)
        {
            _context.Update(room);
        }
    }
}
