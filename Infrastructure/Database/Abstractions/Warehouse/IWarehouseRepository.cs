using Domain.Entity.Entitys;

namespace Infrastructure.Database.Abstractions.Warehouse
{
    /// <summary>
    /// Абстракция репозитория складов
    /// </summary>
    public interface IWarehouseRepository
	{
		/// <summary>
		/// Метод получает конкретный склад
		/// </summary>
		/// <param name="warehouseId">Id склада</param>
		/// <returns></returns>
		Task<WareHouseEntity> GetWarehouseAsync(int warehouseId);

		/// <summary>
		/// Метод создает склад
		/// </summary>
		/// <returns></returns>
		Task CreateWarehouseAsync();

		/// <summary>
		/// Метод добавляет платформы для склада
		/// </summary>
		/// <returns></returns>
		Task AddPlatformWarehouseAsync();
	}
}
