using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetById(Guid id);
        Task<Room> GetByUserId(Guid userId);
        Task<ICollection<Room>> GetAllAsync(Expression<Func<Room, bool>> expression);
        Task AddAsync(Room room);
        void Update(Room room);
        Task<bool> IsMembersOfRoomAsync(Guid id, ICollection<Viewer> viewers);
    }
}
