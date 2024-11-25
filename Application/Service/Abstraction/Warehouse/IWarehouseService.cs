using Domain.Model.Models.Output;

namespace Application.Service.Abstraction.Warehouse
{
	public interface IWarehouseService
	{
		/// <summary>
		/// Метод получает все существующие склады
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<WarehouseOutput>> GetWarehouseAsync();

		/// <summary>
		/// Метод создает склад
		/// </summary>
		/// <returns></returns>
		Task AddWarehouseAsync();

		/// <summary>
		/// Метод удаляет склад
		/// </summary>
		/// <param name="warehouseId">Айди склада</param>
		/// <returns></returns>
		Task<bool> DeleteWarehouseAsync(int warehouseId);
    }
}
