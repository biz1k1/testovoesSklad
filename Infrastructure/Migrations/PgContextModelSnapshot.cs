﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PgContext))]
    partial class PgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

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
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Picket_Id");

                    b.HasOne("Domain.Entity.Entitys.PlatformEntity", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Platform_Id");
                });

            modelBuilder.Entity("Domain.Entity.Entitys.WareHouseEntity", b =>
                {
                    b.Navigation("Platforms");
                });
#pragma warning restore 612, 618
        }
    }
}
