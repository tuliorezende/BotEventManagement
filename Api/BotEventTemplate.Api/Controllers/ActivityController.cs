using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet, Route("{activityId}")]
        public IActionResult Get([FromRoute]string activityId)
        {
            return Ok();
        }

        [HttpPut("{activityId}")]
        public IActionResult Put([FromRoute] string activityId, [FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Activity speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("{activityId}")]
        public IActionResult Delete([FromRoute] string activityId)
        {
            return Ok();
        }
    }
}