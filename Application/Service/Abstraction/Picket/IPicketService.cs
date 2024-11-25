using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output.Picket;

namespace Application.Service.Abstraction.Picket
{
	public interface IPicketService
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
		Task<bool> UpdatePicketAtPlatform(UpdatePicketInput picketInput);

		/// <summary>
		/// Метод удаляет пикет
		/// </summary>
		/// <param name="picketId"></param>
		/// <returns></returns>
		Task<bool> DeleletePicketAsync(int picketId);

        /// <summary>
        /// Метод объединяет пикеты в одну площадку
        /// </summary>
        /// <param name="mergePicketOutput">Входная модель для объединения</param>
        /// <returns></returns>
        Task<bool> MergePicketIntoPlatform(MergePicketOutput mergePicketOutput);
    }
}
