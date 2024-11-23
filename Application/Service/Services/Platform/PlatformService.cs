using Application.Abstraction.Repositories.Platform;
using Application.Exceptions;
using Application.Service.Abstraction.Platform;
using Application.Service.Services.Warehouse;
using AutoMapper;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using Microsoft.Extensions.Logging;

namespace Application.Service.Services.Platform
{
	public class PlatformService : IPlatformService
	{
		private readonly  IPlatformRepository _platformRepository;
		private readonly ILogger<WarehouseService> _logger;
		private readonly IMapper _mapper;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseRepository">Репозиторий склада</param>
		/// <param name="logger">Логер</param>
		public PlatformService(
			IPlatformRepository platformRepository,
			ILogger<WarehouseService> logger,
			IMapper mapper)
		{
			_platformRepository = platformRepository;
			_logger = logger;
			_mapper = mapper;
		}

        #region Публичные методы

        /// <inheritdoc />
        public async Task AddPlatformRepositoryAsync(AddPlatformInput platformInput)
		{
			try
			{
				await _platformRepository.AddPlatformRepositoryAsync(platformInput);
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<IEnumerable<PlatformOutput>> GetAllPlatformAsync()
		{
			try
			{
				var platforms=await _platformRepository.GetAllPlatformAsync();

				var result = _mapper.Map<IEnumerable<PlatformOutput>>(platforms);

				return result;
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task UpdatePlatformAsync(UpdatePlatformInput updateInput)
		{
			try
			{
				await _platformRepository.UpdatePlatformAtWarehouse(updateInput);
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<bool> DeletePlatformAsync(int warehouseId)
        {
            try
            {
                var result = await _platformRepository.DeletePlatformAsync(warehouseId);

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
