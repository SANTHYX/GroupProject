using Core.Commons.Identity;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IdentityToken> Tokens { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Viewer> Viewers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
