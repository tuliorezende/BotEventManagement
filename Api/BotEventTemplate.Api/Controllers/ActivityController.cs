using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.API;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage activities of an specific event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Get activities of an event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            return Ok(_activityService.GetAll(eventId));
        }

        /// <summary>
        /// Get a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet, Route("{activityId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string activityId)
        {
            return Ok(_activityService.GetById(activityId, eventId));
        }

        /// <summary>
        /// Update a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPut("{activityId}")]
        public IActionResult Put([FromRoute] string activityId, [FromBody] ActivityRequest activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (activityId != activity.ActivityId)
                return BadRequest("This id doesn't correspond with object");


            _activityService.Update(activity);

            return NoContent();
        }

        /// <summary>
        /// Create a specific activity of an event
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ActivityRequest activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _activityService.Create(activity);


            return Ok();
        }

        /// <summary>
        /// Remove a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpDelete("{activityId}")]
        public IActionResult Delete([FromHeader] string eventId, [FromRoute] string activityId)
        {
            _activityService.Delete(eventId, activityId);
            return Ok();
        }
    }
}