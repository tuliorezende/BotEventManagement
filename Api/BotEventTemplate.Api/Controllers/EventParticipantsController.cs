﻿using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage Event Participants of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipantsController : ControllerBase
    {
        private readonly IEventParticipantService _eventParticipantsService;
        /// <summary>
        /// Constructor for Event Participants Controller
        /// </summary>
        /// <param name="eventParticipantsService"></param>
        public EventParticipantsController(IEventParticipantService eventParticipantsService)
        {
            _eventParticipantsService = eventParticipantsService;
        }

        /// <summary>
        /// Get Event Participants of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            return Ok(_eventParticipantsService.GetAll(eventId));
        }

        /// <summary>
        /// Get a specific Event Participants of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        [HttpGet, Route("{participantId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string participantId)
        {
            return Ok(_eventParticipantsService.GetById(participantId, eventId));
        }

        /// <summary>
        /// Update a specific Event Participant of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="participantId"></param>
        /// <param name="eventParticipants"></param>
        /// <returns></returns>
        [HttpPut("{participantId}")]
        public IActionResult Put([FromHeader] string eventId, [FromRoute] string participantId, [FromBody] EventParticipantsRequest eventParticipants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (participantId != eventParticipants.Id)
                return BadRequest("This id doesn't correspond with object");

            _eventParticipantsService.Update(eventId, eventParticipants);

            return NoContent();
        }

        /// <summary>
        /// Create an Event Participant of an event
        /// </summary>
        /// <param name="eventParticipants"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EventParticipantsRequest eventParticipants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventParticipantsService.Create(eventParticipants);

            return Ok();
        }
        /// <summary>
        /// Remove an Event Participant of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        [HttpDelete("{participantId}")]
        public IActionResult Delete([FromHeader] string eventId, [FromRoute] string participantId)
        {
            _eventParticipantsService.Delete(participantId, eventId);

            return Ok();
        }

        /// <summary>
        /// Post a sheet to create some Event Participants
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="participantsSheet"></param>
        /// <returns></returns>
        [HttpPost, Route("file")]
        public IActionResult PostFile([FromHeader] string eventId, [FromBody] byte[] participantsSheet)
        {
            _eventParticipantsService.UploadEventParticipantsFile(participantsSheet, eventId);
            return Ok();
        }
    }
}