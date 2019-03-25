using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Models.API;
using BotEventManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage Stages of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStageService _stageService;

        /// <summary>
        /// Stage constructor
        /// </summary>
        /// <param name="stageService"></param>
        public StageController(IStageService stageService)
        {
            _stageService = stageService;
        }


        /// <summary>
        /// Get stages of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            return Ok(_stageService.GetAll(eventId));
        }

        /// <summary>
        /// Get a specific stage of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        [HttpGet, Route("{stageId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string stageId)
        {
            return Ok(_stageService.GetById(stageId, eventId));
        }

        /// <summary>
        /// Update a specific stage of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="stageId"></param>
        /// <param name="stageRequest"></param>
        /// <returns></returns>
        [HttpPut("{stageId}")]
        public IActionResult Put([FromHeader] string eventId, [FromRoute] string stageId, [FromBody] StageRequest stageRequest) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (stageId != stageRequest.StageId)
                return BadRequest("This id doesn't corresponde with object");

            _stageService.Update(stageRequest, eventId);
            return NoContent();
        }

        /// <summary>
        /// Create a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="stage"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromHeader] string eventId, [FromBody] StageRequest stage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _stageService.Create(stage, eventId);

            return Ok();
        }

        /// <summary>
        /// Remove a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="stageId"></param>
        /// <returns></returns>
        [HttpDelete("{stageId}")]
        public IActionResult Delete([FromHeader] string eventId, [FromRoute] string stageId)
        {
            _stageService.Delete(eventId, stageId);
            return Ok();
        }

    }
}