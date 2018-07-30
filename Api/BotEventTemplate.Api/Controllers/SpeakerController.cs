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
    public class SpeakerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet, Route("{speakerId}")]
        public IActionResult Get([FromRoute]string speakerId)
        {
            return Ok();
        }

        [HttpPut("{speakerId}")]
        public IActionResult Put([FromRoute] string speakerId, [FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("{speakerId}")]
        public IActionResult Delete([FromRoute] string speakerId)
        {
            return Ok();
        }
    }
}