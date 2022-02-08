using Core.Domain;
using Core.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetByIdAsync(Guid id);
        Task<Room> GetAggregateByIdAsync(Guid id);
        Task<Room> GetByUserIdAsync(Guid userId);
        Task<Page<Room>> GetAllAsync(Expression<Func<Room, bool>> expression, PagedQuery query);
        Task<bool> IsMembersOfRoomAsync(Guid id, IEnumerable<Viewer> viewers);
        Task AddAsync(Room room);
        void Update(Room room);
    }
}
