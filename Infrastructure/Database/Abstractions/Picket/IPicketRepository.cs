using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Abstractions.Picket
{
	public interface IPicketRepository
	{
		/// <summary>
		/// Метод добавляет пикет (для добавления нужен склад)
		/// </summary>
		/// <param name="warehouseId">Id склада</param>
		/// <returns></returns>
		Task AddPicketAsync(int warehouseId);

	}
}
