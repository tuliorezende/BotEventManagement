using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Models.API;
using BotEventManagement.Web.Api;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Web.Controllers
{
    public class StageController : Controller
    {
        private readonly IEventManagerApi _eventManagerApi;
        public StageController(IEventManagerApi eventManagerApi)
        {
            _eventManagerApi = eventManagerApi;
        }
        public async Task<ActionResult> Index(string id)
        {
            var speakers = await _eventManagerApi.GetAllStagesOfAnEventsAsync(id);

            TempData["EventId"] = id;
            TempData.Keep("EventId");

            return View(speakers);
        }

        public async Task<ActionResult> Details(string id)
        {
            var details = await _eventManagerApi.GetAnStageOfAnEventAsync(TempData.Peek("EventId").ToString(), id);
            return View(details);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StageRequest stageRequest)
        {
            try
            {
                await _eventManagerApi.CreateStageOfAnEventAsync(TempData.Peek("EventId").ToString(), stageRequest);

                return RedirectToAction(nameof(Index), "Stage", new { id = TempData.Peek("EventId").ToString() });
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            var details = await _eventManagerApi.GetAnStageOfAnEventAsync(TempData.Peek("EventId").ToString(), id);

            return View(details);
        }

        // POST: Speaker/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, StageRequest stageRequest)
        {
            try
            {
                await _eventManagerApi.UpdateStageOfAnEventAsync(TempData.Peek("EventId").ToString(), id, stageRequest);
                return RedirectToAction(nameof(Index), "Stage", new { id = TempData.Peek("EventId").ToString() });
            }
            catch
            {
                return View();
            }
        }
    }
}