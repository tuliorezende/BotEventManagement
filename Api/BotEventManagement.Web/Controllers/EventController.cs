using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Models.API;
using BotEventManagement.Web.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManagerApi _eventManagerApi;

        public EventController(IEventManagerApi eventManagerApi)
        {
            _eventManagerApi = eventManagerApi;
        }
        // GET: Event
        public async Task<ActionResult> Index()
        {
            var events = await _eventManagerApi.GetAllEventsAsync();
            return View(events);
        }

        // GET: Event/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var specificEvent = await _eventManagerApi.GetSpecificEventAsync(id);

            TempData["EventId"] = id;
            TempData.Keep("EventId");

            return View(specificEvent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventRequest eventRequest)
        {
            try
            {
                // TODO: Add insert logic here
                await _eventManagerApi.CreateAnEventAsync(eventRequest);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var specificEvent = await _eventManagerApi.GetSpecificEventAsync(id);
            return View(specificEvent);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EventRequest eventRequest)
        {
            try
            {
                await _eventManagerApi.UpdateAnEventAsync(id, eventRequest);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}