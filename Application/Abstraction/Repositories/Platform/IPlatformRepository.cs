using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Input.Platform;

namespace Application.Abstraction.Repositories.Platform
{
	public interface IPlatformRepository
	{

		/// <summary>
		/// Метод получает все существующие площадки
		/// </summary>
		/// <returns></returns>
		Task<ICollection<PlatformEntity>> GetAllPlatformAsync();

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
