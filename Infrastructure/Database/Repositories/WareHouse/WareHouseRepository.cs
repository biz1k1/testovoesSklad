using Domain.Entity.Entitys;
using Infrastructure.Data;
using Infrastructure.Database.Abstractions.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.WareHouse
{
    /// <summary>
    /// Класс реализует методы репозитория складов
    /// </summary>
    internal sealed class WareHouseRepository:IWarehouseRepository
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

		public async Task<ICollection<WareHouseEntity>> GetWarehouseAsync()
		{
			var result = await _pgContext.WareHouses.ToListAsync();

			return result;
		}
		#endregion
	}
}
