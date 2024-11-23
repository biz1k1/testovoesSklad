using Application.Abstraction.Repositories.Warehouse;
using Domain.Entity.Entitys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.WareHouse
{
    /// <summary>
    /// Класс реализует методы репозитория складов
    /// </summary>
    internal sealed class WareHouseRepository: IWarehouseRepository
	{
        private readonly PgContext _pgContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pgContext"></param>
        public WareHouseRepository(PgContext pgContext)
        {
            _pgContext = pgContext;
        }

        #region Публичные методы

        /// <inheritdoc />
        public async Task AddWarehouseAsync()
		{

			var lastWarehouseId = _pgContext.WareHouses.
                OrderByDescending(x => x.Id)
                .FirstOrDefault();

			var newId = lastWarehouseId != null ? lastWarehouseId.Id + 1 : 1;
			var newName = $"Склад {newId}";  

			var wareHouse = new WareHouseEntity
			{
				Name=newName,
			};

			await _pgContext.WareHouses.AddAsync(wareHouse);

            await _pgContext.SaveChangesAsync();
		}

        /// <inheritdoc />
        public async Task<IEnumerable<WareHouseEntity>> GetWarehouseAsync()
		{
			var result = await _pgContext.WareHouses.Include(x=>x.Platforms).ThenInclude(x=>x.Pickets).ToListAsync();

			return result;
		}

        /// <inheritdoc />
        public async Task<bool> DeleteWarehouseAsync(int warehouseId)
		{
			var warehouse = await _pgContext.WareHouses.Where(x => x.Id == warehouseId)
				.Include(x => x.Platforms).FirstOrDefaultAsync();

			var warehousePlatform = warehouse.Platforms.Count();

			if (warehouse is null || warehousePlatform is not 0)
			{
				return false;
			}

			_pgContext.WareHouses.Remove(warehouse);

            await _pgContext.SaveChangesAsync();

            return true;
        }

		#endregion
	}
}
