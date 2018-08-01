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
        private ICrudElements<Speaker> _speakerService;
        public SpeakerController(ICrudElements<Speaker> speakerService)
        {
            _speakerService = speakerService;
        }
        /// <summary>
        /// Get speakers of an event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_speakerService.GetAll());
        }

        /// <summary>
        /// Get specific speaker of an event
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpGet, Route("{speakerId}")]
        public IActionResult Get([FromRoute]string speakerId)
        {
            return Ok(_speakerService.GetById(speakerId));
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

            _speakerService.Update(speaker);

            return Ok();
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
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpDelete("{speakerId}")]
        public IActionResult Delete([FromRoute] string speakerId)
        {
            _speakerService.Delete(speakerId);
            return Ok();
        }
    }
}