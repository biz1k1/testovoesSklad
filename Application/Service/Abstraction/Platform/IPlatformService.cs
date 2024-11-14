using Domain.Entity.Entitys;
using Domain.Model.Models.Input.Platform;
using Domain.Model.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Models.Output.Platform;

namespace Application.Service.Abstraction.Platform
{
	public interface IPlatformService
	{
		/// <summary>
		/// Метод получает все существующие площадки
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<PlatformOutput>> GetAllPlatformAsync();

		/// <summary>
		/// Метод добавляет площадку (для добавления нужен пикет)
		/// </summary>
		/// <param name="picketId">Id пикета</param>
		/// <returns></returns>
		Task AddPlatformRepositoryAsync(AddPlatformInput platformInput);

		/// <summary>
		/// Метод обновляет груз и/или склад
		/// </summary>
		/// <param name="platformInput">Входная модель для обновления</param>
		/// <returns></returns>
		Task UpdatePlatformAsync(UpdatePlatformInput platformInput);
	}
}
