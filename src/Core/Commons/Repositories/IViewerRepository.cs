using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IViewerRepository : IRepository
    {
        Task<Viewer> GetById(Guid id);
        Task<ICollection<Viewer>> GetAllByUserIdCollection(IEnumerable<Guid> userIdCollection);
        Task AddManyAsync(ICollection<Viewer> viewers);
    }
}
