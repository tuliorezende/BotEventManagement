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
    /// Manage Event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private ICrudElements<Event> _eventService;
        public EventController(ICrudElements<Event> eventService)
        {
            _eventService = eventService;
        }
        /// <summary>
        /// Get events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventService.GetAll());
        }

        /// <summary>
        /// Get a specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet, Route("{eventId}")]
        public IActionResult Get([FromRoute]string eventId)
        {
            return Ok(_eventService.GetById(eventId));
        }

        /// <summary>
        /// Update a specific event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut("{eventId}")]
        public IActionResult Put([FromRoute] string eventId, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (eventId != @event.EventId)
                return BadRequest("This id doesn't correspond with object");


            _eventService.Update(@event);

            return NoContent();
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventService.Create(@event);

            return Ok();
        }

        /// <summary>
        /// Remove an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete("{eventId}")]
        public IActionResult Delete([FromRoute] string eventId)
        {
            _eventService.Delete(eventId);
            return Ok();
        }
    }
}