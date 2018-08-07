using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage Speakers of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private ICrudElementsWIthEventFilter<Speaker> _speakerService;
        public SpeakerController(ICrudElementsWIthEventFilter<Speaker> speakerService)
        {
            _speakerService = speakerService;
        }

        /// <summary>
        /// Get speakers of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            return Ok(_speakerService.GetAll(eventId));
        }

        /// <summary>
        /// Get specific speaker of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpGet, Route("{speakerId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string speakerId)
        {
            return Ok(_speakerService.GetById(speakerId, eventId));
        }

        /// <summary>
        /// Update a specific speaker of an event
        /// </summary>
        /// <param name="speakerId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPut("{speakerId}")]
        public IActionResult Put([FromRoute] string speakerId, [FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (speakerId != speaker.SpeakerId)
                return BadRequest("This id doesn't correspond with object");

            _speakerService.Update(speaker);

            return NoContent();
        }

        /// <summary>
        /// Create a specific speaker of an event
        /// </summary>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _speakerService.Create(speaker);

            return Ok();
        }

        /// <summary>
        /// Remove a specific speaker of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpDelete("{speakerId}")]
        public IActionResult Delete([FromHeader] string eventId, [FromRoute] string speakerId)
        {
            _speakerService.Delete(eventId, speakerId);
            return Ok();
        }
    }
}