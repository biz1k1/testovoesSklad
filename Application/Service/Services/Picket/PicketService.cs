using Application.Abstraction.Repositories.Picket;
using Application.Service.Abstraction.Picket;
using Application.Service.Services.Warehouse;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Microsoft.Extensions.Logging;
using Application.Exceptions;
using Application.Abstraction.Repositories.Platform;
using Domain.Model.Models.Output.Picket;


namespace Application.Service.Services.Picket
{
	public class PicketService:IPicketService
	{
		private readonly IPicketRepository _picketRepository;
		private readonly ILogger<WarehouseService> _logger;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseRepository">Репозиторий склада</param>
		/// <param name="logger">Логер</param>
		public PicketService(
			IPicketRepository picketRepository,
			ILogger<WarehouseService> logger)
		{
			_picketRepository = picketRepository;
			_logger = logger;
		}


        #region Публичные методы

        /// <inheritdoc />
        public async Task AddPicketAsync(int platformId)
		{
			try
			{
				await _picketRepository.AddPicketAsync(platformId);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<IEnumerable<PicketEntity>> GetAllPicketsAsync()
		{
			try
			{
				return await _picketRepository.GetAllPicketsAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<bool> UpdatePicketAtPlatform(UpdatePicketInput picketInput)
		{
			try
			{
				var result=await _picketRepository.UpdatePicketAtPlatform(picketInput);

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<bool> DeleletePicketAsync(int picketId)
        {
            try
            {
                var result = await _picketRepository.DeletePicketAsync(picketId);

				return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ServiceException(ex.Message);
            }
        }

        /// <inheritdoc />
        public async Task<bool> MergePicketIntoPlatform(MergePicketOutput mergePicketOutput)
		{
            try
            {
                var result = await _picketRepository.MergePicketIntoPlatform(mergePicketOutput);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ServiceException(ex.Message);
            }
        }
        #endregion

    }
}
