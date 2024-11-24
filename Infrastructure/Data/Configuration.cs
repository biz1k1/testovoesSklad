using Domain.Entity.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    /// <summary>
    /// Класс конфигурации таблицы складов
    /// </summary>
    public class WareHouseConfiguration : IEntityTypeConfiguration<WareHouseEntity>
	{
		public void Configure(EntityTypeBuilder<WareHouseEntity> builder)
		{
			builder.ToTable("WareHouses");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired();
		} 
	}

	/// <summary>
	/// Класс конфигурации таблицы платформ
	/// </summary>
	public class PlatformConfiguration : IEntityTypeConfiguration<PlatformEntity>
	{
		public void Configure(EntityTypeBuilder<PlatformEntity> builder)
		{
			builder.ToTable("Platforms");

			builder.HasKey(x => x.Id);
			
			builder.HasOne(x => x.WareHouse)
				.WithMany(q => q.Platforms)
				.HasForeignKey(x => x.WareHouseId);

			builder.Property(x=>x.Date)
                 .HasColumnType("text");
            builder.Property(x => x.Number)
				.IsRequired();
		}
	}

	/// <summary>
	/// Класс конфигурации таблицы пикетов
	/// </summary>
	public class PicketConfiguration : IEntityTypeConfiguration<PicketEntity>
	{
		public void Configure(EntityTypeBuilder<PicketEntity> builder)
		{
			builder.ToTable("Pickets");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Number)
				.IsRequired();

			builder.HasMany(x => x.Platforms)
				.WithMany(x => x.Pickets)
				.UsingEntity("PlatformsPickets");
		}
	}
}
