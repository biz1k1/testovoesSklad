using Domain.Entity.Entitys;
using Domain.Model.Models.Output.Warehouse;

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
	}
}
