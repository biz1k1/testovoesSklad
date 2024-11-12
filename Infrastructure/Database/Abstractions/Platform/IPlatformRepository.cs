using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Abstractions.Platform
{
	public interface IPlatformRepository
	{
		/// <summary>
		/// Метод добавляет площадку (для добавления нужен пикет)
		/// </summary>
		/// <param name="picketId">Id пикета</param>
		/// <returns></returns>
		Task AddPlatformRepository(int picketId);

	}
}
