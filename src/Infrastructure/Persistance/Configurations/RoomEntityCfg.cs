using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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
            builder.HasMany(x => x.Chat)
                .WithOne(y => y.Room);
            builder.HasMany(x => x.Viewers)
                .WithMany(y => y.Rooms)
                .UsingEntity<Dictionary<string, object>>
                    ("Session",
                        j => j.HasOne<Viewer>()
                            .WithMany()
                            .HasForeignKey("ViewerId"),
                        j => j.HasOne<Room>()
                            .WithMany()
                            .HasForeignKey("RoomId")
                    );
            builder.HasMany(x => x.Movies)
                .WithMany(y => y.Rooms)
                .UsingEntity<Dictionary<string, object>>
                    (
                    "RoomsMovies",
                        j => j.HasOne<Movie>()
                        .WithMany()
                        .HasForeignKey("MovieId"),
                            j => j.HasOne<Room>()
                            .WithMany()
                            .HasForeignKey("RoomId")
                    );
        }
    }
}
