﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PgContext))]
    [Migration("20241121215232_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Entitys.PicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pickets", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Entitys.PlatformEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Cargo")
                        .HasColumnType("double precision");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("WareHouseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WareHouseId");

                    b.ToTable("Platforms", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Entitys.WareHouseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WareHouses", (string)null);
                });

            modelBuilder.Entity("PlatformsPickets", b =>
                {
                    b.Property<int>("PicketsId")
                        .HasColumnType("integer");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("integer");

                    b.HasKey("PicketsId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("PlatformsPickets");
                });

            modelBuilder.Entity("Domain.Entity.Entitys.PlatformEntity", b =>
                {
                    b.HasOne("Domain.Entity.Entitys.WareHouseEntity", "WareHouse")
                        .WithMany("Platforms")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("PlatformsPickets", b =>
                {
                    b.HasOne("Domain.Entity.Entitys.PicketEntity", null)
                        .WithMany()
                        .HasForeignKey("PicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Entitys.PlatformEntity", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Entitys.WareHouseEntity", b =>
                {
                    b.Navigation("Platforms");
                });
#pragma warning restore 612, 618
        }
    }
}