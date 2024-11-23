using Application.Service.Abstraction.Picket;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
		public async Task<IEnumerable<PicketEntity>> GetAllPicketsAsync()
		{
			var result = await _picketService.GetAllPicketsAsync();

			return result;
		}

		/// <summary>
		/// Метод создает пикет
		/// </summary>
		/// <param name="platformId">Id платформы, в который добавится пикет</param>
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
		[Route("picket-details")]
		public async Task UpdatePicketsAsync([FromBody] UpdatePicketInput picketInput)
		{
			await _picketService.UpdatePicketsAsync(picketInput);
		}

		/// <summary>
		/// Метод удаляет пикет
		/// </summary>
		/// <param name="picketId">Айди пикета</param>
		/// <returns></returns>
        [HttpDelete]
        [Route("picket-delete")]
        public async Task<bool> DeletePicketAsync (int picketId)
        {
            var result= await _picketService.DeleletePicketAsync(picketId);

			return result;
        }
    }
}
