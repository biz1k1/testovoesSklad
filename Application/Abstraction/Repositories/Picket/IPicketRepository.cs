using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output.Picket;

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
        /// <param name="updateInput">Входная модель для обновления пикетов</param>
        /// <returns></returns>
        Task<bool> UpdatePicketAtPlatform(UpdatePicketInput updateInput);

        /// <summary>
        /// Метод удаляет пикет
        /// </summary>
        /// <param name="picketId">Айди пикета</param>
        /// <returns></returns>
        Task<bool> DeletePicketAsync(int picketId);

        /// <summary>
        /// Метод объединяет пикеты в одну площадку
        /// </summary>
        /// <param name="mergePicketOutput">Входная модель для объединения</param>
        /// <returns></returns>
        Task<bool> MergePicketIntoPlatform(MergePicketOutput mergePicketOutput);

    }
}
