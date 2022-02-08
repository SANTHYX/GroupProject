using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Configurations
{
    public class ViewerEntityCfg : IEntityTypeConfiguration<Viewer>
    {
        public void Configure(EntityTypeBuilder<Viewer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.isOnline);
            builder.HasMany(x => x.Rooms)
                .WithMany(y => y.Viewers)
                .UsingEntity<Dictionary<string, object>>
                    ("Session",
                        j => j.HasOne<Room>()
                            .WithMany()
                            .HasForeignKey("RoomId"),
                        j => j.HasOne<Viewer>()
                            .WithMany()
                            .HasForeignKey("ViewerId")
                    );
        }
    }
}
