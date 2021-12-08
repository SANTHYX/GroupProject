using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetById(Guid id);
        Task<Room> GetByUserId(Guid userId);
        Task<ICollection<Room>> GetAllPublicAsync();
        Task AddAsync(Room room);
        void Update(Room room);
    }
}
