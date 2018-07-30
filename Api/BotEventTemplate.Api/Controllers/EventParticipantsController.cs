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
    public class EventParticipantsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet, Route("{participantId}")]
        public IActionResult Get([FromRoute]string participantId)
        {
            return Ok();
        }

        [HttpPut("{participantId}")]
        public IActionResult Put([FromRoute] string participantId, [FromBody] EventParticipants eventParticipants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] EventParticipants eventParticipants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("{participantId}")]
        public IActionResult Delete([FromRoute] string participantId)
        {
            return Ok();
        }

        [HttpPost, Route("file")]
        public IActionResult PostFile(byte[] participantsSheet)
        {
            return Ok();
        }
    }
}