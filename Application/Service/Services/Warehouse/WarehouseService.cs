using Application.Abstraction.Repositories.Warehouse;
using Application.Exceptions;
using Application.Service.Abstraction.Warehouse;
using Domain.Entity.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.Service.Services.Warehouse
{
	public class WarehouseService : IWarehouseService
	{
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly ILogger<WarehouseService> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseRepository">Репозиторий склада</param>
		/// <param name="logger">Логер</param>
		public WarehouseService(
			IWarehouseRepository warehouseRepository,
			ILogger<WarehouseService> logger)
		{
			_warehouseRepository = warehouseRepository;
			_logger = logger;
		}
		#region Публичные методы
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

		public async Task<ICollection<WareHouseEntity>> GetWarehouseAsync()
		{
			try
			{
				var result = await _warehouseRepository.GetWarehouseAsync();

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
