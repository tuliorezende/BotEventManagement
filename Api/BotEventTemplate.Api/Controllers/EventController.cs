﻿using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage Event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        /// <summary>
        /// Constructor for Event Controller
        /// </summary>
        /// <param name="eventService"></param>
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        /// <summary>
        /// Get events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var userId = User.Identity.Name;
            return Ok(_eventService.GetAll(userId));
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
        /// <param name="eventId"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut("{eventId}")]
        public IActionResult Put([FromRoute] string eventId, [FromBody] EventRequest @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (eventId != @event.Id)
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
        [Authorize]
        public IActionResult Post([FromBody] EventRequest @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Identity.Name;
            _eventService.Create(@event, userId);

            return Ok();
        }

        /// <summary>
        /// Remove an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete("{eventId}")]
        [Authorize]
        public IActionResult Delete([FromRoute] string eventId)
        {
            var userId = User.Identity.Name;

            _eventService.Delete(userId, eventId);
            return Ok();
        }
    }
}