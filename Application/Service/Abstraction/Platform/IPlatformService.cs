using Domain.Model.Models.Input;
using Domain.Model.Models.Output;

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

		/// <summary>
		/// Метод удаляет площадку
		/// </summary>
		/// <param name="warehouseId">Айди площадки</param>
		/// <returns></returns>
		Task<bool> DeletePlatformAsync(int warehouseId);

    }
}
