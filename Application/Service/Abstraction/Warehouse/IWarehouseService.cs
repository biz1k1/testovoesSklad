using Domain.Entity.Entitys;

namespace Application.Service.Abstraction.Warehouse
{
	public interface IWarehouseService
	{
		/// <summary>
		/// Метод получает все существующие склады
		/// </summary>
		/// <returns></returns>
		Task<ICollection<WareHouseEntity>> GetWarehouseAsync();

		/// <summary>
		/// Метод создает склад
		/// </summary>
		/// <returns></returns>
		Task AddWarehouseAsync();
	}
}
