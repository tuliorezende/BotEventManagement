using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage activities from an specific event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        /// <summary>
        /// Constructor for Activity Controller
        /// </summary>
        /// <param name="activityService"></param>
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Get activities of an event
        /// </summary>
        /// <param name="eventId">Event Id</param>
        /// <param name="stageId">Stage id</param>
        /// <param name="day">Selected Date</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId, [FromQuery]string stageId, [FromQuery] string day)
        {
            return Ok(_activityService.GetAll(eventId, stageId, day));
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
        /// <param name="eventId"></param>
        /// <param name="activityId"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPut("{activityId}")]
        public IActionResult Put([FromHeader] string eventId, [FromRoute] string activityId, [FromBody] ActivityRequest activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (activityId != activity.ActivityId)
                return BadRequest("This id doesn't correspond with object");

            _activityService.Update(activity, eventId);

            return NoContent();
        }

        /// <summary>
        /// Create a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromHeader] string eventId, [FromBody] ActivityRequest activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _activityService.Create(activity, eventId);


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