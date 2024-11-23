using Application.Service.Abstraction.Platform;
using Application.Validation;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using FluentValidation;
using FluentValidation.Results;
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
		private readonly IValidator<AddPlatformInput> _validator;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="platformService"></param>
        public PlatformController(
			IPlatformService platformService,
			IValidator<AddPlatformInput> validator)
		{
			_platformService = platformService;
			_validator = validator;
		}
		
		/// <summary>
		/// Метод получает список площадок
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("platform-lists")]
		public async Task<IEnumerable<PlatformOutput>> GetAllPlatformAsync()
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
		public async Task<IActionResult> AddPlatformRepositoryAsync([FromBody] AddPlatformInput platformInput)
		{
            var validationResult = await _validator.ValidateAsync(platformInput);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(BehaviorException.AddToModelState(validationResult));
            }
            await _platformService.AddPlatformRepositoryAsync(platformInput);

			return Ok(true);
		}

		/// <summary>
		/// Метод обновляет площадку
		/// </summary>
		/// <param name="platformInput"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("platform-details")]
		public async Task UpdatePlatformAsync([FromBody] UpdatePlatformInput platformInput)
		{
			await _platformService.UpdatePlatformAsync(platformInput);
		}

        /// <summary>
        /// Метод удаляет площадку
        /// </summary>
        /// <param name="platformId">Айди площадки</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("platform-delete")]
        public async Task<bool> DeletePicketAsync(int platformId)
        {
            var result = await _platformService.DeletePlatformAsync(platformId);

            return result;
        }
    }
}
