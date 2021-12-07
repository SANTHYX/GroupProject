using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class UserEntityCfg : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login);

            builder.Property(x => x.Password);

            builder.Property(x => x.Salt);

            builder.HasMany(x => x.IdentityTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.User);

            builder.HasOne(x => x.Viewer)
                .WithOne(y => y.User);
        }
    }
}
