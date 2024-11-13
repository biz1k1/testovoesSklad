using Domain.Entity;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input.Picket;
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
		/// Метод получат все существующие пикеты
		/// </summary>
		/// <returns></returns>
		Task<ICollection<PicketEntity>> GetAllPicketsAsync();

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
