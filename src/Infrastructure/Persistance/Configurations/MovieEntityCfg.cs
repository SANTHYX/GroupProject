using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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
            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasMany(x => x.Rooms)
                .WithMany(y => y.Movies)
                .UsingEntity<Dictionary<string, object>>
                    (
                    "RoomMovies",
                        j => j.HasOne<Room>()
                        .WithMany()
                        .HasForeignKey("RoomId"),
                            j => j.HasOne<Movie>()
                            .WithMany()
                            .HasForeignKey("MovieId")
                    );
        }
    }
}
