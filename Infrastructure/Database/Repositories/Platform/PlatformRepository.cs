using Application.Abstraction.Repositories.Platform;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Input.Platform;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Platform
{
	internal sealed class PlatformRepository : IPlatformRepository
	{
		private readonly PgContext _pgContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="pgContext"></param>
		public PlatformRepository(PgContext pgContext)
		{
			_pgContext = pgContext;
		}

		#region Публичные методы
		public async Task AddPlatformRepositoryAsync(AddPlatformInput platformInput)
		{
			var lastPlatformeId = _pgContext.Platforms.
				OrderByDescending(x => x.Id)
				.FirstOrDefault();

			var newId = lastPlatformeId != null ? lastPlatformeId.Id + 1 : 1;

			var wareHouse = new PlatformEntity
			{
				Number = newId,
				WareHouseId = platformInput.WarehouseId,
				Cargo = platformInput.Cargo
			};

			await _pgContext.Platforms.AddAsync(wareHouse);

			await _pgContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<PlatformEntity>> GetAllPlatformAsync()
		{
			var result = await _pgContext.Platforms.ToListAsync();

			return result;
		}

		public async Task UpdatePlatformAsync(UpdatePlatformInput platformInput)
		{
			var updateResult = new PlatformEntity
			{
				Cargo = platformInput.Cargo,
				Id=platformInput.Id

			};

			_pgContext.Platforms.Update(updateResult);

			await _pgContext.SaveChangesAsync();
		}
		#endregion
	}
}
