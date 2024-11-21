using Domain.Entity.Entitys;
using Domain.Model.Models.Input;

namespace Application.Abstraction.Repositories.Picket
{
	public interface IPicketRepository
	{
		/// <summary>
		/// Метод получат все существующие пикеты
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<PicketEntity>> GetAllPicketsAsync();

		/// <summary>
		/// Метод создает пикет (для добавления нужен площадка)
		/// </summary>
		/// <param name="platformId">Id площадки</param>
		/// <returns></returns>
		Task AddPicketAsync(int platformId);

		/// <summary>
		/// Переназначить пикеты на другие платформы
		/// </summary>
		/// <param name="picketInput">Входная модель для обновления пикетов</param>
		/// <returns></returns>
		Task UpdatePicketsAsync(UpdatePicketInput picketInput);

	}
}
