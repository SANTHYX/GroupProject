using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class ViewerEntityCfg : IEntityTypeConfiguration<Viewer>
    {
        public void Configure(EntityTypeBuilder<Viewer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Rooms)
                .WithMany(y => y.Viewers)
                .UsingEntity(t => t.ToTable("Session"));
        }
    }
}
