﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211202150738_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Commons.Identity.IdentityToken", b =>
                {
                    b.Property<string>("Refresh")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpirationTime")
                        .HasMaxLength(30)
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRevoked")
                        .HasMaxLength(3)
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Refresh")
                        .HasName("Refresh");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityToken");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Commons.Identity.IdentityToken", b =>
                {
                    b.HasOne("Core.Domain.User", "User")
                        .WithMany("IdentityTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Navigation("IdentityTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
