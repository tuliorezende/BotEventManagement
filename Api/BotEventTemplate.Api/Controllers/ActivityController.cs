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
    /// Manage activities of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        /// <summary>
        /// Get activities of an event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Get a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet, Route("{activityId}")]
        public IActionResult Get([FromRoute]string activityId)
        {
            return Ok();
        }

        /// <summary>
        /// Update a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPut("{activityId}")]
        public IActionResult Put([FromRoute] string activityId, [FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        /// <summary>
        /// Create a specific activity of an event
        /// </summary>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        /// <summary>
        /// Remove a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpDelete("{activityId}")]
        public IActionResult Delete([FromRoute] string activityId)
        {
            return Ok();
        }
    }
}