using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// <summary>
        /// Get speakers of an event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Get specific speaker of an event
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpGet, Route("{speakerId}")]
        public IActionResult Get([FromRoute]string speakerId)
        {
            return Ok();
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
            return Ok();
        }
    }
}