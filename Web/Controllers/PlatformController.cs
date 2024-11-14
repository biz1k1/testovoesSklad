using Application.Service.Abstraction.Platform;
using Application.Service.Abstraction.Warehouse;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Input.Platform;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	/// <summary>
	/// Контроллер работы с площадками
	/// </summary>
	[ApiController]
	[Route("Platform")]
	public class PlatformController:ControllerBase
	{
		private readonly IPlatformService _platformService;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="platformService"></param>
		public PlatformController(
			IPlatformService platformService)
		{
			_platformService = platformService;
		}
		
		/// <summary>
		/// Метод получает список площадок
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("platform-lists")]
		public async Task<ICollection<PlatformEntity>> GetAllPlatformAsync()
		{
			var result = await _platformService.GetAllPlatformAsync();

			return result;
		}

		/// <summary>
		/// Метод добавляет площадку
		/// </summary>
		/// <param name="platformInput"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("platform")]
		public async Task AddPlatformRepositoryAsync(AddPlatformInput platformInput)
		{
			await _platformService.AddPlatformRepositoryAsync(platformInput);
		}

		/// <summary>
		/// Метод обновляет площадку
		/// </summary>
		/// <param name="platformInput"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("platform-details")]
		public async Task UpdatePlatformAsync(UpdatePlatformInput platformInput)
		{
			await _platformService.UpdatePlatformAsync(platformInput);
		}

	}
}
