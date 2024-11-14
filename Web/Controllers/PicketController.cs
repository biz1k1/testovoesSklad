using Application.Service.Abstraction.Picket;
using Application.Service.Abstraction.Platform;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input.Picket;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	/// <summary>
	/// Контроллер работы с пикетами
	/// </summary>
	[ApiController]
	[Route("Picket")]
	public class PicketController:ControllerBase
	{
		private readonly IPicketService _picketService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="picketService"></param>
		public PicketController(
			IPicketService picketService)
		{
			_picketService = picketService;
		}
		/// <summary>
		/// Метод получает список пикетов
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route(template: "picket-lists")]
		public async Task<ICollection<PicketEntity>> GetAllPicketsAsync()
		{
			var result = await _picketService.GetAllPicketsAsync();

			return result;
		}

		/// <summary>
		/// Метод создает пикет
		/// </summary>
		/// <param name="platformId"></param>
		/// <returns></returns>
		[HttpPost]
		[Route(template: "picket")]
		public async Task AddPicketAsync(int platformId)
		{
			await _picketService.AddPicketAsync(platformId);
		}

		/// <summary>
		/// Метод обновляет данные пикета
		/// </summary>
		/// <param name="picketInput"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("platform-details")]
		public async Task UpdatePicketsAsync(UpdatePicketInput picketInput)
		{
			await _picketService.UpdatePicketsAsync(picketInput);
		}

	}
}
