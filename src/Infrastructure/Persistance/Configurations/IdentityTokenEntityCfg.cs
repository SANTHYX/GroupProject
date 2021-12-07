using Core.Commons.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class IdentityTokenEntityCfg : IEntityTypeConfiguration<IdentityToken>
    {
        public void Configure(EntityTypeBuilder<IdentityToken> builder)
        {
            builder.HasKey(x => x.Refresh);

            builder.Property(x => x.ExpirationTime)
                .HasMaxLength(30);

            builder.Property(x => x.IsRevoked)
                .HasMaxLength(3);

            builder.HasOne(x => x.User)
                .WithMany(x => x.IdentityTokens);
        }
    }
}
