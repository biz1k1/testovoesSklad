using Application.Abstraction.Repositories.Picket;
using Application.Exceptions;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output.Picket;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

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

        /// <inheritdoc />
        public async Task AddPicketAsync(int platformId)
		{
			var platform =await _pgContext.Platforms.FirstOrDefaultAsync(x=>x.Id==platformId);

			if(platform is null)
			{
				throw new NotFoundPlatformException(platformId);
			}

			var lastPicketId = _pgContext.Pickets.
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

			newPicket.Platforms.Add(platform);

			await _pgContext.SaveChangesAsync();
			
		}

        /// <inheritdoc />
        public async Task<IEnumerable<PicketEntity>> GetAllPicketsAsync()
		{
			var result = await _pgContext.Pickets.ToListAsync();

			return result;
		}

        /// <inheritdoc />
        public async Task<bool> DeletePicketAsync(int picketId)
        {
			var picket = await _pgContext.Pickets.Where(x => x.Id == picketId).FirstOrDefaultAsync();

            if (picket is null)
            {
                return false;
            }

            _pgContext.Pickets.Remove(picket);

			await _pgContext.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> UpdatePicketAtPlatform(UpdatePicketInput updateInput)
		{

			var platform = await _pgContext.Platforms.Where(x => x.Id == updateInput.PlatformId)
				.FirstOrDefaultAsync(); 

			var picket = await _pgContext.Pickets.Where(x => x.Id == updateInput.PicketId)
				.Include(x=>x.Platforms).FirstOrDefaultAsync();

			//Если не удалось найти пикет и платформу
			if(platform is null || picket is null)
			{
				return false;
			}

			// Удаление пикета из площадки, в которой он находится и переназначение на другую площадку
			var platformPicketId = picket.Platforms.Select(x => x.Id).FirstOrDefault();

			var platformFromRemovePicket = await _pgContext.Platforms.Include(x => x.Pickets)
				.FirstOrDefaultAsync(x => x.Id == platformPicketId);

			if(platformFromRemovePicket is not null)
			{
				platformFromRemovePicket.Pickets.Remove(picket);

				_pgContext.Platforms.Update(platformFromRemovePicket);
			}

			//Если на площадке после переноса не осталось пикетов
			if(platformFromRemovePicket.Pickets.Count is 0)
			{
                _pgContext.Platforms.Remove(platformFromRemovePicket);
            }


			//Добавление пикета в новую площадку

			platform.Pickets.Add(picket);

			await _pgContext.SaveChangesAsync();

			return true;
		}

		/// <inheritdoc />
		public async Task<bool> MergePicketIntoPlatform(MergePicketOutput mergePicketOutput)
		{
			var pickets = _pgContext.Platforms.SelectMany(p => p.Pickets)
				.Include(x => x.Platforms).ThenInclude(x => x.WareHouse)
				.Where(p => mergePicketOutput.picketIds.Contains(p.Number)).Distinct().ToList();

			// Не удалось найти пикеты
			if (!pickets.Any())
			{
				throw new NotFoundPicketException();
			}

			var warehouses = pickets.SelectMany(picket => picket.Platforms)
				.Select(platform => platform.WareHouse).Distinct().ToList();

			// Если уникальный склад только один, то пикеты на одном складе
			// Если нет, то кидает ошибку
			if (warehouses.Count is not 1)
			{
				throw new Exception();
			}

			// Сумма всех грузов у платформ пикетов
			var summaryCargoPlatform = pickets.SelectMany(x => x.Platforms).Select(x => x.Cargo).Sum();

			// Создаем новую площадку
			var newPlatform = new PlatformEntity
			{
				Number = $"{pickets.First().Number}-{pickets.Last().Number}",
				Cargo = summaryCargoPlatform,
				WareHouseId = mergePicketOutput.WarehouseId,
				Pickets = pickets
			};


			// Убираем связь пикетов с их старыми площадками
			foreach (var picket in pickets)
			{
				foreach (var oldPlatform in picket.Platforms.ToList())
				{
					oldPlatform.Pickets.Remove(picket);
					picket.Platforms.Remove(oldPlatform);
				}
			}

			// Добавляем новую площадку в список
			_pgContext.Platforms.Add(newPlatform);

			_pgContext.Pickets.UpdateRange(pickets);



			await _pgContext.SaveChangesAsync();

			return true;

		}
		#endregion
	}
}
