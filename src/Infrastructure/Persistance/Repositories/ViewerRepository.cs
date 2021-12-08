using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    class ViewerRepository : IViewerRepository
    {
        private readonly DataContext _context;

        public ViewerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Viewer> GetById(Guid id)
            => await _context.Viewers.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ICollection<Viewer>> GetAllByUserIdCollection(ICollection<Guid> userIdCollection) 
            => await _context.Viewers
            .Where(x => userIdCollection.Contains(x.UserId))
            .ToListAsync();

        public async Task AddManyAsync(ICollection<Viewer> viewers)
        {
            await _context.Viewers.AddRangeAsync(viewers);
        }
    }
}
