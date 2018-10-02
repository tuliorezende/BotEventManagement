using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.API;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage User Talks of an event
    /// </summary>
    [Route("api/[controller]")]
    public class UserTalksController : Controller
    {
        private readonly IUserTalksService _userTalksService;
        public UserTalksController(IUserTalksService userTalksService)
        {
            _userTalksService = userTalksService;
        }

        /// <summary>
        /// Create an user talk
        /// </summary>
        /// <param name="userTalks"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] UserTalksRequest userTalks)
        {
            _userTalksService.Create(userTalks);
            return Ok();
        }

        /// <summary>
        /// Delete an User Talk entry
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromHeader] string userId, [FromRoute] string activityId)
        {
            _userTalksService.Delete(userId, activityId);
            return Ok();
        }


        /// <summary>
        /// Get all user talks of specific event
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll([FromHeader] string userId, string eventId)
        {
            return Ok(_userTalksService.GetAll(userId, eventId));
        }

    }
}