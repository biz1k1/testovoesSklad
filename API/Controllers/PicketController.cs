﻿using Application.Service.Abstraction.Picket;
using Application.Validation;
using Domain.Entity.Entitys;
using Domain.Model.Models.Input;
using Domain.Model.Models.Output.Picket;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Контроллер работы с пикетами
    /// </summary>
    [ApiController]
    [Route("pickets")]
    public class PicketController : ControllerBase
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
        [Route("{platformId}")]
        public async Task AddPicketAsync(int platformId)
        {
            await _picketService.AddPicketAsync(platformId);
        }

        /// <summary>
        /// Метод обновляет пикет у площадки
        /// </summary>
        /// <param name="picketInput"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("picket-details")]
        public async Task<IActionResult> UpdatePicketsAsync([FromBody] UpdatePicketInput picketInput)
        {
            var validationResult = await new PicketAddValidator().ValidateAsync(picketInput);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(BehaviorException.AddToModelState(validationResult));
            }

            var result = await _picketService.UpdatePicketAtPlatform(picketInput);

            return Ok();
        }

        /// <summary>
        /// Метод удаляет пикет
        /// </summary>
        /// <param name="picketId">Айди пикета</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{picketId}")]
        public async Task<bool> DeletePicketAsync(int picketId)
        {
            var result = await _picketService.DeleletePicketAsync(picketId);

            return result;
        }

        /// <summary>
        /// Метод объединяет пикеты в площадку
        /// </summary>
        /// <param name="mergePicketOutput"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("merge")]
        public async Task<IActionResult> MergePicketIntoPlatform([FromBody] MergePicketOutput mergePicketOutput)
        {

            var validationResult = await new PicketMergeValidator().ValidateAsync(mergePicketOutput);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(BehaviorException.AddToModelState(validationResult));
            }
            var result = await _picketService.MergePicketIntoPlatform(mergePicketOutput);

            return Ok(true);
        }
    }
}
