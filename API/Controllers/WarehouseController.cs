using Application.Service.Abstraction.Warehouse;
using Domain.Model.Models.Output;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	/// <summary>
	/// Контроллер работы со складами
	/// </summary>
	[ApiController]
	[Route("Warehouse")]
	public class WarehouseController: ControllerBase
	{
		private readonly IWarehouseService _warehouseService;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="warehouseService"></param>
		public WarehouseController(
			IWarehouseService warehouseService)
		{
			_warehouseService = warehouseService;
		}

		/// <summary>
		/// Метод получает список складов
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("Warehouse-list")]
		public async Task<IEnumerable<WarehouseOutput>> GetWarehouseAsync()
		{
			var result = await _warehouseService.GetWarehouseAsync();

			return result;
		}

		/// <summary>
		/// Метод добавляет склад
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("Warehouse")]
		public async Task AddWarehouseAsync()
		{
			await _warehouseService.AddWarehouseAsync();
		}

        /// <summary>
        /// Метод удаляет склад
        /// </summary>
        /// <param name="warehouseId">Айди склада</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("warehouse-delete")]
        public async Task<bool> DeletePicketAsync(int warehouseId)
        {
            var result = await _warehouseService.DeleteWarehouseAsync(warehouseId);

            return result;
        }
    }
}
