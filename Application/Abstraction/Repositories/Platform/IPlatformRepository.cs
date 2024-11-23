using Domain.Entity.Entitys;
using Domain.Model.Models.Input;

namespace Application.Abstraction.Repositories.Platform
{
	public interface IPlatformRepository
	{

		/// <summary>
		/// Метод получает все существующие площадки
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<PlatformEntity>> GetAllPlatformAsync();

		/// <summary>
		/// Метод добавляет площадку 
		/// </summary>
		/// <param name="platformInput">Входна ямодель для добавления</param>
		/// <returns></returns>
		Task AddPlatformRepositoryAsync(AddPlatformInput platformInput);

		/// <summary>
		/// Метод обновляет груз и/или склад
		/// </summary>
		/// <param name="platformInput">Входная модель для обновления</param>
		/// <returns></returns>
		Task UpdatePlatformAsync(UpdatePlatformInput platformInput);

		/// <summary>
		/// Метод удаляет платформу
		/// </summary>
		/// <param name="platformId">Айди платформы</param>
		/// <returns></returns>
		Task<bool> DeletePlatformAsync(int platformId);


    }
}
