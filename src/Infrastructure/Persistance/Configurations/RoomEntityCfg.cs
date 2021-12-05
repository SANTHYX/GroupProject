using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class RoomEntityCfg : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(y => y.Rooms)
                .HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Movies)
                .WithOne(y => y.Room);
        }
    }
}
