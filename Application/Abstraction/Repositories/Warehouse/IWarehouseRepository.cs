using Domain.Entity.Entitys;

namespace Application.Abstraction.Repositories.Warehouse
{
    /// <summary>
    /// Абстракция репозитория складов
    /// </summary>
    public interface IWarehouseRepository
	{
		/// <summary>
		/// Метод получает все существующие склады
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<WareHouseEntity>> GetWarehouseAsync();

		/// <summary>
		/// Метод создает склад
		/// </summary>
		/// <returns></returns>
		/// 
		Task AddWarehouseAsync();

		/// <summary>
		/// Метод удаляет склад
		/// </summary>
		/// <param name="warehouseId">Айди склада</param>
		/// <returns></returns>
		Task<bool> DeleteWarehouseAsync(int warehouseId);

    }
}
