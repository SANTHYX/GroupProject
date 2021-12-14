using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

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
            .Include(x => x.Viewers)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Room> GetByUserId(Guid userId)
            => await _context.Rooms.FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task<ICollection<Room>> GetAllAsync(Expression<Func<Room, bool>> expression)
            => await _context.Rooms
            .Where(expression)
            .ToListAsync();

        public async Task AddAsync(Room room)
        {
            await _context.AddAsync(room);
        }

        public void Update(Room room)
        {
            _context.Update(room);
        }

        public async Task<bool> IsMembersOfRoomAsync(Guid id, ICollection<Viewer> viewers)
            => await _context.Rooms.AnyAsync(x => x.Id == id && x.Viewers.Any(z => viewers.Contains(z)));
    }
}
