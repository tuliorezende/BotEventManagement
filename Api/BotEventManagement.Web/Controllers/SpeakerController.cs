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
    public class SpeakerController : Controller
    {
        private readonly IEventManagerApi _eventManagerApi;
        public SpeakerController(IEventManagerApi eventManagerApi)
        {
            _eventManagerApi = eventManagerApi;
        }
        // GET: Speaker
        /// <summary>
        /// Method to return all speakers of an event
        /// </summary>
        /// <param name="id">event Id</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string id)
        {
            var speakers = await _eventManagerApi.GetAllSpeakersOfAnEventsAsync(id);

            TempData["EventId"] = id;
            TempData.Keep("EventId");

            return View(speakers);
        }

        // GET: Speaker/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var details = await _eventManagerApi.GetASpeakerOfAnEventAsync(TempData.Peek("EventId").ToString(), id);
            return View(details);
        }

        // GET: Speaker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speaker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SpeakerRequest speakerRequest)
        {
            try
            {
                // TODO: Add insert logic here
                await _eventManagerApi.CreateSpeakerOfAnEventAsync(TempData.Peek("EventId").ToString(), speakerRequest);

                return RedirectToAction(nameof(Index), "Speaker", new { id = TempData.Peek("EventId").ToString() });
            }
            catch
            {
                return View();
            }
        }

        // GET: Speaker/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var details = await _eventManagerApi.GetASpeakerOfAnEventAsync(TempData.Peek("EventId").ToString(), id);

            return View(details);
        }

        // POST: Speaker/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, SpeakerRequest speakerRequest)
        {
            try
            {
                await _eventManagerApi.UpdateASpeakersOfAnEventAsync(TempData.Peek("EventId").ToString(), id, speakerRequest);
                return RedirectToAction(nameof(Index), "Speaker", new { id = TempData.Peek("EventId").ToString() });
            }
            catch
            {
                return View();
            }
        }
    }
}