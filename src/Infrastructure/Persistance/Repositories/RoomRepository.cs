using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Core.Types;

namespace Infrastructure.Persistance.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        private readonly IPaging<Room> _page;

        public RoomRepository(DataContext context, IPaging<Room> page)
        {
            _context = context;
            _page = page;
        }

        public async Task<Room> GetByIdAsync(Guid id)
            => await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Room> GetAggregateByIdAsync(Guid id)
        => await _context.Rooms
            .AsNoTracking()
            .Include(x => x.Chat)
            .Include(x => x.Movies)
            .Include(x => x.Viewers)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Room> GetByUserIdAsync(Guid userId)
            => await _context.Rooms.FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task<Page<Room>> GetAllAsync(Expression<Func<Room, bool>> expression, PagedQuery query)
        { 
            var data = _context.Rooms
                .AsNoTracking()
                .Where(expression);

            return await _page.GetPagedResultAsync(data, query.Page, query.Results);
        }

        public async Task<bool> IsMembersOfRoomAsync(Guid id, ICollection<Viewer> viewers)
            => await _context.Rooms
            .AsNoTracking()
            .AnyAsync(x => x.Id == id && x.Viewers.Any(z => viewers.Contains(z)));

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
