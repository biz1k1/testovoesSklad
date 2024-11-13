using Domain.Entity.Entitys;

namespace Infrastructure.Database.Abstractions.Warehouse
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
		Task<ICollection<WareHouseEntity>> GetWarehouseAsync();

		/// <summary>
		/// Метод создает склад
		/// </summary>
		/// <returns></returns>
		Task AddWarehouseAsync();
	}
}
