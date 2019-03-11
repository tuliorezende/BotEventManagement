using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
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
        private readonly ISpeakerService _speakerService;
        /// <summary>
        /// Constructor for Speaker Controller
        /// </summary>
        /// <param name="speakerService"></param>
        public SpeakerController(ISpeakerService speakerService)
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
        /// <param name="eventId"></param>
        /// <param name="speakerId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPut("{speakerId}")]
        public IActionResult Put([FromHeader] string eventId, [FromRoute] string speakerId, [FromBody] SpeakerRequest speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (speakerId != speaker.SpeakerId)
                return BadRequest("This id doesn't correspond with object");

            _speakerService.Update(speaker, eventId);

            return NoContent();
        }

        /// <summary>
        /// Create a specific speaker of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromHeader] string eventId, [FromBody] SpeakerRequest speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _speakerService.Create(speaker, eventId);

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