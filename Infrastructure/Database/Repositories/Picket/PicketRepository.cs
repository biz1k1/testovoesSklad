using Application.Abstraction.Repositories.Picket;
using Application.Exceptions;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
		}

        /// <inheritdoc />
        public async Task<bool> DeletePicketAsync(int picketId)
        {
			var picket = await _pgContext.Pickets.Where(x => x.Id == picketId).FirstOrDefaultAsync();

            if (picket is null )
            {
                return false;
            }

            _pgContext.Pickets.Remove(picket);

			await _pgContext.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
