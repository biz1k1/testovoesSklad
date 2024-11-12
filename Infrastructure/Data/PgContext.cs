using Domain.Entity.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class PgContext:DbContext
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="options"></param>
		public PgContext(DbContextOptions<PgContext> options) : base(options)
		{
		}
		
		/// <summary>
		/// Таблица складов
		/// </summary>
		public DbSet<WareHouseEntity> WareHouses { get; set; }

		/// <summary>
		/// Таблица платформ
		/// </summary>
		public DbSet<PlatformEntity> Platforms { get; set; }

		/// <summary>
		/// Таблица пикетов
		/// </summary>
		public DbSet<PicketEntity> Pickets { get; set; }

		/// <summary>
		/// Применение конфигураций таблиц 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
				Assembly.GetExecutingAssembly()
				);

			base.OnModelCreating(modelBuilder);
		}
	}
}
