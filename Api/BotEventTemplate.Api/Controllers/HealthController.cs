using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Controller to validate api health
    /// </summary>
    [Route("/healthz")]
    public class HealthController : Controller
    {

        /// <summary>
        /// Method to validate api health
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Health Controller - Before Health return");
            return Ok("success");
        }
    }
}