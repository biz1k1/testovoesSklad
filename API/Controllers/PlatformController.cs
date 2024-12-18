﻿using Application.Service.Abstraction.Platform;
using Application.Validation;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Контроллер работы с площадками
    /// </summary>
    [ApiController]
    [Route("platforms")]
    public class PlatformController : ControllerBase
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
        /// Метод получает список площадок со вложенными в них пикетами
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
            var validationResult = await new PlatformAddValidator().ValidateAsync(platformInput);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(BehaviorException.AddToModelState(validationResult));
            }
            await _platformService.AddPlatformRepositoryAsync(platformInput);

            return Ok(true);
        }

        /// <summary>
        /// Метод обновляет площадку у склада
        /// </summary>
        /// <param name="updateInput"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("platform-details")]
        public async Task<IActionResult> UpdatePlatformAsync([FromBody] UpdatePlatformInput updateInput)
        {
            var validationResult = await new PlatformUpdateValidator().ValidateAsync(updateInput);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(BehaviorException.AddToModelState(validationResult));
            }

            await _platformService.UpdatePlatformAsync(updateInput);

            return Ok(true);

        }

        /// <summary>
        /// Метод удаляет площадку
        /// </summary>
        /// <param name="platformId">Айди площадки</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{platformId}")]
        public async Task<bool> DeletePicketAsync(int platformId)
        {
            var result = await _platformService.DeletePlatformAsync(platformId);

            return result;
        }
    }
}
