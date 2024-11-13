using Application.Abstraction.Repositories.Platform;
using Application.Service.Abstraction.Platform;
using Application.Service.Abstraction.Warehouse;
using Application.Service.Services.Warehouse;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Input.Platform;
using Microsoft.Extensions.Logging;

namespace Application.Service.Services.Platform
{
	public class PlatformService : IPlatformService
	{
		private readonly  IPlatformRepository _platformRepository;
		private readonly ILogger<WarehouseService> _logger;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseRepository">Репозиторий склада</param>
		/// <param name="logger">Логер</param>
		public PlatformService(
			IPlatformRepository platformRepository,
			ILogger<WarehouseService> logger)
		{
			_platformRepository = platformRepository;
			_logger = logger;
		}

		#region Публичные методы
		public async Task AddPlatformRepositoryAsync(AddPlatformInput platformInput)
		{
			try
			{
				await _platformRepository.AddPlatformRepositoryAsync(platformInput);
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, ex.Message);
				throw;
			}
		}

		public async Task<ICollection<PlatformEntity>> GetAllPlatformAsync()
		{
			try
			{
				return await _platformRepository.GetAllPlatformAsync();
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, ex.Message);
				throw;
			}
		}

		public async Task UpdatePlatformAsync(UpdatePlatformInput platformInput)
		{
			try
			{
				await _platformRepository.UpdatePlatformAsync(platformInput);
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
