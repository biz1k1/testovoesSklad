using Application.Abstraction.Repositories.Warehouse;
using Application.Exceptions;
using Application.Service.Abstraction.Warehouse;
using AutoMapper;
using Domain.Model.Models.Output;
using Microsoft.Extensions.Logging;

namespace Application.Service.Services.Warehouse
{
	public class WarehouseService : IWarehouseService
	{
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly ILogger<WarehouseService> _logger;
		private readonly IMapper _mapper;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseRepository">Репозиторий склада</param>
		/// <param name="logger">Логер</param>
		public WarehouseService(
			IWarehouseRepository warehouseRepository,
			ILogger<WarehouseService> logger,
			IMapper mapper)
		{
			_warehouseRepository = warehouseRepository;
			_logger = logger;
			_mapper = mapper;
		}
        #region Публичные методы

        /// <inheritdoc />
        public async Task AddWarehouseAsync()
		{
			try
			{
				await _warehouseRepository.AddWarehouseAsync();
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<IEnumerable<WarehouseOutput>> GetWarehouseAsync()
		{
			try
			{
				var warehouses = await _warehouseRepository.GetWarehouseAsync();

				var result = _mapper.Map<IEnumerable<WarehouseOutput>>(warehouses);

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServiceException(ex.Message);
			}
		}

        /// <inheritdoc />
        public async Task<bool> DeleteWarehouseAsync(int warehouseId)
		{
			try
			{
				var result=await _warehouseRepository.DeleteWarehouseAsync(warehouseId);

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
