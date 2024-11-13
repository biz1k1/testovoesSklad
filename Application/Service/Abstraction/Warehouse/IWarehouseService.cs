using Domain.Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
