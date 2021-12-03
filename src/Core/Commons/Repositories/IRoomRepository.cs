using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetById(Guid id);
        Task AddAsync(Room room);
        void Update(Room room);
    }
}
