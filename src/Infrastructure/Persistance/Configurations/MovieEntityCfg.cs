using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class MovieEntityCfg : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName)
                .HasMaxLength(42)
                .IsRequired();
            builder.HasOne(x => x.Room)
                .WithMany(y => y.Movies)
                .HasForeignKey(x => x.RoomId);
        }
    }
}
