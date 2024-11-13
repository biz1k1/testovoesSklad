using Application.Service.Abstraction.Warehouse;
using Domain.Entity.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.Service.Services.Warehouse
{
	public class WarehouseServices : IWarehouseService
	{
		private readonly IWarehouseService _warehouseRepository;
		private readonly ILogger<WarehouseServices> _logger;
		public WarehouseServices(
			IWarehouseService warehouseRepository,
			ILogger<WarehouseServices> logger)
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
				throw;
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
				throw;
			}
		}
		#endregion
	}
}
