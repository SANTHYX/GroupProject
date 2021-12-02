﻿using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public sealed class UserEntityCfg : IEntityTypeConfiguration<User>
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
        }
    }
}