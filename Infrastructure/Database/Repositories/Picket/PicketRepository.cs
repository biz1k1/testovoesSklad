using Application.Exception;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input.Picket;
using Infrastructure.Data;
using Infrastructure.Database.Abstractions.Picket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.Picket
{
	internal sealed class PicketRepository : IPicketRepository
	{
		private readonly PgContext _pgContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="pgContext"></param>
		public PicketRepository(PgContext pgContext)
		{
			_pgContext = pgContext;
		}

		#region Публичные методы
		public async Task AddPicketAsync(int platformId)
		{
			var platform =await _pgContext.Platforms.FirstOrDefaultAsync(x=>x.Id==platformId);

			if(platform is null)
			{
				throw new NotFoundPlatformException(platformId);
			}

			var lastPicketId = _pgContext.WareHouses.
				OrderByDescending(x => x.Id)
				.FirstOrDefault();

			var newId = lastPicketId != null ? lastPicketId.Id + 1 : 1;

			// Добавление нового пикета
			var newPicket = new PicketEntity
			{
				Number = newId,
			};

			await _pgContext.Pickets.AddAsync(newPicket);

			// Присваивание пикета к площадке
			platform.Pickets.Add(newPicket);

			await _pgContext.SaveChangesAsync();
			
		}

		public async Task<ICollection<PicketEntity>> GetAllPicketsAsync()
		{
			var result = await _pgContext.Pickets.ToListAsync();

			return result;
		}

		public async Task UpdatePicketsAsync(UpdatePicketInput updatePicketInput)
		{
			var platform = await _pgContext.Platforms.FirstOrDefaultAsync(x => x.Id == updatePicketInput.PlatformId);

			if (platform is null)
			{
				throw new NotFoundPlatformException(updatePicketInput.PlatformId);
			}

			var picket= await _pgContext.Pickets.FirstOrDefaultAsync(x => x.Id == updatePicketInput.PicketId);

			if (platform is null)
			{
				throw new NotFoundPicketException(updatePicketInput.PicketId);
			}

			
			//Удаляем пикет из платформы
			
			//Добавляем пикет в новую платформу
		}
		#endregion
	}
}
