using Application.Abstraction.Repositories.Platform;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
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

        /// <inheritdoc />
        public async Task AddPlatformRepositoryAsync(AddPlatformInput platformInput)
		{
			var lastPlatformeId = _pgContext.Platforms.
				OrderByDescending(x => x.Id)
				.FirstOrDefault();

			var newId = lastPlatformeId != null ? lastPlatformeId.Id + 1 : 1;

			var platform = new PlatformEntity
			{
				Number = newId,
				WareHouseId = platformInput.WarehouseId,
				Cargo = platformInput.Cargo
			};

			await _pgContext.Platforms.AddAsync(platform);

			await _pgContext.SaveChangesAsync();
		}

        /// <inheritdoc />
        public async Task<IEnumerable<PlatformEntity>> GetAllPlatformAsync()
		{
			var result = await _pgContext.Platforms.Include(x=>x.Pickets).ToListAsync();

			return result;
		}

        /// <inheritdoc />
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

        /// <inheritdoc />
		public async Task<bool> DeletePlatformAsync(int platformId)
		{
            var platform = await _pgContext.Platforms.Where(x => x.Id == platformId)
				.Include(x => x.Pickets).FirstOrDefaultAsync();

            var platformPickets = platform.Pickets.Count();

            if (platform is null || platformPickets is not 0)
            {
                return false;
            }

			_pgContext.Platforms.Remove(platform);

            await _pgContext.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
